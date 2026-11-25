import { useState } from 'react';
import {
  Container,
  Typography,
  Alert,
  Snackbar,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Button,
  Divider,
} from '@mui/material';
import EventBusyIcon from '@mui/icons-material/EventBusy';
import { useDiscontinuities } from '../../hooks/useDiscontinuities';
import { useStudents } from '../../hooks/useStudents';
import type { DiscontinuityDTO, DiscontinuityCreateDTO } from '../../types/discontinuity.types';
import DiscontinuityList from './DiscontinuityList';
import DiscontinuityForm from './DiscontinuityForm';


// ============================================================================
// 🏛️ SAYFA BİLEŞENİ: DiscontinuityPage (Devamsızlık Yönetim Sayfası)
// ============================================================================
// Bu sayfa Devamsızlık modülünün ana konteyneridir (Container Component):
// 1. Durum Yönetimi (State):
//    - `editingDiscontinuity`: Hangi devamsızlık kaydının düzenlendiğini tutar (null ise ekleme modudur).
//    - `deleteTarget`: Silinmek üzere modalda onay bekleyen kaydı tutar.
//    - `snackbar`: İşlem başarıyla bittiğinde ekranda çıkan yeşil bildirim metnidir.
// 2. Form ve Liste Entegrasyonu:
//    - `useDiscontinuities` ile devamsızlık listesi ve CRUD fonksiyonlarını yönetir.
//    - `useStudents` ile öğrencileri çekip formdaki Dropdown menüsüne besler.
// 3. React Key Pattern:
//    - `formKey`: `editingDiscontinuity` değiştiğinde formu yeniden mount ettirerek
//      inputların güncel verilerle dolmasını sağlar (React 19 cascading render çözümü).
// ============================================================================

export default function DiscontinuityPage() {
  // --------------------------------------------------------------------------
  // 1. Hook'lardan CRUD İşlemlerini ve Verileri Çekme
  // --------------------------------------------------------------------------
  const {
    discontinuities,
    loading,
    error,
    addDiscontinuity,
    updateDiscontinuity,
    deleteDiscontinuity,
  } = useDiscontinuities();

  // Formda öğrenci seçebilmek için öğrenci listesini çekiyoruz
  const { students } = useStudents();

  // --------------------------------------------------------------------------
  // 2. Sayfa İçi Durumlar (Page State)
  // --------------------------------------------------------------------------
  // Düzenleme modundaki devamsızlık nesnesi (Düzenleme yoksa null)
  const [editingDiscontinuity, setEditingDiscontinuity] =
    useState<DiscontinuityDTO | null>(null);

  // Silinmek istenen devamsızlık nesnesi (Modal açık/kapalı durumunu da kontrol eder)
  const [deleteTarget, setDeleteTarget] = useState<DiscontinuityDTO | null>(null);

  // İşlem başarılı olduğunda altta beliren bildirim mesajı
  const [snackbar, setSnackbar] = useState<string | null>(null);

  // --------------------------------------------------------------------------
  // 3. CRUD Olay Yöneticileri (Event Handlers)
  // --------------------------------------------------------------------------

  // Formdan veri geldiğinde: Düzenleme modundaysa PUT, yeni kayıt ise POST atar
  const handleSubmit = async (data: DiscontinuityCreateDTO) => {
    if (editingDiscontinuity) {
      // PUT /api/Discontinuity/{id}
      await updateDiscontinuity(editingDiscontinuity.id, data);
      setEditingDiscontinuity(null); // Düzenleme modunu sonlandır
      setSnackbar('Devamsızlık kaydı başarıyla güncellendi.');
    } else {
      // POST /api/Discontinuity
      await addDiscontinuity(data);
      setSnackbar('Devamsızlık kaydı başarıyla eklendi.');
    }
  };

  // Tablodan "Düzenle" butonuna tıklandığında kaydı düzenleme state'ine alır
  const handleEdit = (discontinuity: DiscontinuityDTO) => {
    setEditingDiscontinuity(discontinuity);
  };

  // Düzenlemeden vazgeçilip "İptal" butonuna basıldığında formu temizler
  const handleCancelEdit = () => {
    setEditingDiscontinuity(null);
  };

  // Tablodan "Sil" butonuna tıklandığında silme onay modalını açar
  const handleDeleteClick = (id: number) => {
    const target = discontinuities.find((d) => d.id === id) ?? null;
    setDeleteTarget(target);
  };

  // Silme onay modalında "Sil" butonuna basıldığında DELETE isteği atar
  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;
    // DELETE /api/Discontinuity/{id}
    await deleteDiscontinuity(deleteTarget.id);
    setDeleteTarget(null); // Modalı kapat
    setSnackbar('Devamsızlık kaydı başarıyla silindi.');
  };

  // React 19 Key Pattern: editingDiscontinuity id değiştikçe form sıfırdan render olur
  const formKey = editingDiscontinuity
    ? `edit-${editingDiscontinuity.id}`
    : 'create';

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      {/* Sayfa Başlığı */}
      <Typography
        variant="h4"
        gutterBottom
        sx={{ display: 'flex', alignItems: 'center', gap: 1 }}
      >
        <EventBusyIcon fontSize="large" color="primary" />
        Devamsızlık Yönetimi
      </Typography>

      <Divider sx={{ mb: 3 }} />

      {/* API Hata Mesajı (Varsa Kırmızı Alert kutusu olarak gösterilir) */}
      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {/* Devamsızlık Ekle / Güncelle Formu */}
      <DiscontinuityForm
        key={formKey}
        onSubmit={handleSubmit}
        initialData={editingDiscontinuity}
        students={students}
        isEditing={Boolean(editingDiscontinuity)}
        onCancel={handleCancelEdit}
      />

      <Divider sx={{ my: 3 }} />

      {/* Devamsızlık Listesi Tablosu */}
      <DiscontinuityList
        discontinuities={discontinuities}
        loading={loading}
        students={students}
        onEdit={handleEdit}
        onDelete={handleDeleteClick}
      />

      {/* Silme Onay Modalı (MUI Dialog) */}
      <Dialog
        open={Boolean(deleteTarget)}
        onClose={() => setDeleteTarget(null)}
      >
        <DialogTitle>Devamsızlık Kaydını Sil</DialogTitle>
        <DialogContent>
          <DialogContentText>
            <strong>{deleteTarget?.studentName ?? `ID: ${deleteTarget?.studentID}`}</strong> öğrencisine
            ait bu devamsızlık kaydını silmek istediğinize emin misiniz? Bu işlem geri alınamaz.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setDeleteTarget(null)} color="inherit">
            İptal
          </Button>
          <Button
            onClick={handleDeleteConfirm}
            color="error"
            variant="contained"
          >
            Sil
          </Button>
        </DialogActions>
      </Dialog>

      {/* İşlem Başarı Bildirimi (MUI Snackbar) */}
      <Snackbar
        open={Boolean(snackbar)}
        autoHideDuration={3000}
        onClose={() => setSnackbar(null)}
        message={snackbar}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
      />
    </Container>
  );
}
