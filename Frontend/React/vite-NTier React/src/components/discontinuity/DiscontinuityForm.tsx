import { useState } from 'react';
import {
  Box,
  TextField,
  Button,
  Stack,
  Typography,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  FormControlLabel,
  Switch,
} from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import type { DiscontinuityCreateDTO } from '../../types/discontinuity.types';
import type { StudentDTO } from '../../types/student.types';

// ============================================================================
// 📝 UI FORMU: DiscontinuityForm (Devamsızlık Ekleme ve Güncelleme Formu)
// ============================================================================
// Bu bileşen hem "Yeni Devamsızlık Ekleme" hem de "Mevcut Devamsızlığı Güncelleme"
// işlemlerini tek bir form üzerinden yönetir.
//
// 1. `isEditing`: Formun güncelleme modunda mı yoksa ekleme modunda mı olduğunu belirtir.
// 2. `initialData`: Düzenleme modunda seçilen kaydın verilerini form kutucuklarına doldurur.
// 3. `students`: Öğrenci ID'si girmek yerine kullanıcı dostu bir Dropdown (Select)
//    üzerinden öğrenci seçilmesini sağlar.
// ============================================================================

interface DiscontinuityFormProps {
  /** Form gönderildiğinde (Kaydet/Güncelle) çalışacak asenkron fonksiyon */
  onSubmit: (data: DiscontinuityCreateDTO) => Promise<void>;
  /** Düzenlenecek kaydın başlangıç verileri (varsa) */
  initialData?: DiscontinuityCreateDTO | null;
  /** Dropdown menüsünde listelenecek öğrenci listesi */
  students?: StudentDTO[];
  /** Formun düzenleme modunda olup olmadığı */
  isEditing?: boolean;
  /** Düzenleme modundan vazgeçildiğinde çağrılacak iptal fonksiyonu */
  onCancel?: () => void;
}

export default function DiscontinuityForm({
  onSubmit,
  initialData,
  students = [],
  isEditing = false,
  onCancel,
}: DiscontinuityFormProps) {
  // --------------------------------------------------------------------------
  // 🧩 Form Alanları için Yerel State (Local State) Tanımları
  // --------------------------------------------------------------------------
  // Seçilen öğrencinin ID'si (Başlangıçta seçili öğrenci veya boş string)
  const [studentID, setStudentID] = useState<number | ''>(
    initialData?.studentID ?? ''
  );

  // Devamsızlık tarihi: Düzenleniyorsa mevcut tarih, yeni ekleniyorsa bugünün tarihi (YYYY-MM-DD)
  const [dateofDiscontinuity, setDateofDiscontinuity] = useState<string>(
    initialData?.dateofDiscontinuity
      ? initialData.dateofDiscontinuity.substring(0, 10)
      : new Date().toISOString().substring(0, 10)
  );

  // Devamsızlık gün sayısı (Varsayılan: 1 gün)
  const [days, setDays] = useState<number | ''>(initialData?.days ?? 1);

  // Özür durumu: Raporlu/izinli mi (true) yoksa özürsüz mü (false)
  const [excuse, setExcuse] = useState<boolean>(initialData?.excuse ?? false);

  // Butona basıldığında birden fazla istek atılmasını önleyen yüklenme durumu
  const [submitting, setSubmitting] = useState(false);

  // --------------------------------------------------------------------------
  // 🚀 Form Gönderme (Submit) Olayı
  // --------------------------------------------------------------------------
  const handleSubmit = async (e: React.FormEvent) => {
    // Sayfanın varsayılan HTML form davranışı ile yenilenmesini engeller
    e.preventDefault();

    // Zorunlu alanların dolu olduğunu doğrula
    if (studentID === '' || !dateofDiscontinuity || days === '') return;

    setSubmitting(true);
    try {
      // Backend'in beklediği DTO formatında veriyi üst bileşene (DiscontinuityPage) ilet
      await onSubmit({
        studentID: Number(studentID),
        dateofDiscontinuity: `${dateofDiscontinuity}T00:00:00`, // ISO tarih formatına tamamla
        days: Number(days),
        excuse: excuse,
      });

      // Eğer yeni ekleme modundaysak, başarılı kayıttan sonra formu temizle
      if (!isEditing) {
        setStudentID('');
        setDateofDiscontinuity(new Date().toISOString().substring(0, 10));
        setDays(1);
        setExcuse(false);
      }
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mb: 3 }}>
      {/* Form Başlığı: Düzenleme moduna göre ikon ve metin değişir */}
      <Typography variant="h6" gutterBottom>
        {isEditing ? '✏️ Devamsızlık Kaydını Güncelle' : '➕ Yeni Devamsızlık Ekle'}
      </Typography>

      <Stack spacing={2}>
        {/* Üst Satır: Öğrenci Seçimi, Devamsızlık Tarihi ve Gün Sayısı */}
        <Stack direction={{ xs: 'column', sm: 'row' }} spacing={2} sx={{ alignItems: 'center' }}>
          
          {/* 1. Öğrenci Seçim Menüsü (MUI Select) */}
          <FormControl size="small" fullWidth required>
            <InputLabel id="student-select-label">Öğrenci</InputLabel>
            <Select<number | ''>
              labelId="student-select-label"
              value={studentID}
              label="Öğrenci"
              onChange={(e) =>
                setStudentID(e.target.value ? Number(e.target.value) : '')
              }
            >
              <MenuItem value="">
                <em>Öğrenci Seçiniz</em>
              </MenuItem>
              {students.map((student) => (
                <MenuItem key={student.id} value={student.id}>
                  {student.name} (Öğrenci No: {student.id})
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          {/* 2. Devamsızlık Tarihi Seçimi (HTML5 Date Picker) */}
          <TextField
            label="Devamsızlık Tarihi"
            type="date"
            value={dateofDiscontinuity}
            onChange={(e) => setDateofDiscontinuity(e.target.value)}
            required
            size="small"
            fullWidth
            slotProps={{
              inputLabel: { shrink: true }, // Etiketin tarih ile çakışmasını önler
            }}
          />

          {/* 3. Gün Sayısı Girişi */}
          <TextField
            label="Gün Sayısı"
            type="number"
            value={days}
            onChange={(e) =>
              setDays(e.target.value ? Number(e.target.value) : '')
            }
            required
            size="small"
            sx={{ minWidth: 120 }}
            slotProps={{ htmlInput: { min: 1, step: 1 } }}
          />
        </Stack>

        {/* Alt Satır: Özür Durumu Switch'i ve İşlem Butonları */}
        <Stack
          direction="row"
          spacing={2}
          sx={{ alignItems: 'center', justifyContent: 'space-between' }}
        >
          {/* 4. Özürlü/Özürsüz Durumu (MUI Switch) */}
          <FormControlLabel
            control={
              <Switch
                checked={excuse}
                onChange={(e) => setExcuse(e.target.checked)}
                color="warning"
              />
            }
            label={excuse ? 'Özürlü / İzinli (Raporlu)' : 'Özürsüz'}
          />

          {/* 5. Butonlar: Kaydet/Güncelle ve İptal */}
          <Stack direction="row" spacing={1}>
            <Button
              type="submit"
              variant="contained"
              disabled={submitting || studentID === '' || days === ''}
              startIcon={<SaveIcon />}
              color={isEditing ? 'warning' : 'primary'}
            >
              {submitting ? 'Kaydediliyor...' : isEditing ? 'Güncelle' : 'Ekle'}
            </Button>
            {isEditing && onCancel && (
              <Button
                variant="outlined"
                color="inherit"
                onClick={onCancel}
                startIcon={<CancelIcon />}
              >
                İptal
              </Button>
            )}
          </Stack>
        </Stack>
      </Stack>
    </Box>
  );
}
