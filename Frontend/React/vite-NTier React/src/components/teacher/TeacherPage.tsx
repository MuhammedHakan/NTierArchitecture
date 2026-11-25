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
import SchoolIcon from '@mui/icons-material/School';
import  useTeachers  from '../../hooks/useTeachers';
import type { TeacherDTO, TeacherCreateDTO } from '../../types/teacher.types';
import  useLessons  from '../../hooks/useLessons'; // 👈 1. Hook'u import edin
import TeacherList from './TeacherList';
import TeacherForm from './TeacherForm';
export default function TeacherPage() {
  const { teachers, loading, error, addTeacher, updateTeacher, deleteTeacher } =
    useTeachers();
  const { lessons } = useLessons(); 
  const [editingTeacher, setEditingTeacher] = useState<TeacherDTO | null>(null);
  const [deleteTarget, setDeleteTarget] = useState<TeacherDTO | null>(null);
  const [snackbar, setSnackbar] = useState<string | null>(null);

  const handleSubmit = async (data: TeacherCreateDTO) => {
    if (editingTeacher) {
      await updateTeacher(editingTeacher.id, data);
      setEditingTeacher(null);
      setSnackbar('Öğretmen başarıyla güncellendi.');
    } else {
      await addTeacher(data);
      setSnackbar('Öğretmen başarıyla eklendi.');
    }
  };

  const handleEdit = (lesson: TeacherDTO) => {
    setEditingTeacher(lesson);
  };

  const handleCancelEdit = () => {
    setEditingTeacher(null);
  };

  const handleDeleteClick = (id: number) => {
  // 💡 ÇÖZÜM: 
  // 1. Dizi olan 'teachers' üzerinde .find() çağırın.
  // 2. TypeScript 's' parametresinin otomatik olarak TeacherDTO olduğunu anlar.
  // 3. Bulamazsa undefined yerine null dönsün diye '?? null' ekleyin.
  const targetTeacher = teachers.find((e) => e.id === id) ?? null;

  setDeleteTarget(targetTeacher);
};

  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;
    await deleteTeacher(deleteTarget.id);
    setDeleteTarget(null);
    setSnackbar('Öğretmen başarıyla silindi.');
  };

  const formKey = editingTeacher ? `edit-${editingTeacher.id}` : 'create';

  return(
    <Container maxWidth="md" sx={{ py: 4 }}>
      {/* Başlık */}
      <Typography
        variant="h4"
        gutterBottom
        sx={{ display: 'flex', alignItems: 'center', gap: 1 }}
      >
        <SchoolIcon fontSize="large" color="primary" />
        Öğretmen Yönetimi
      </Typography>

      <Divider sx={{ mb: 3 }} />

      {/* Hata mesajı */}
      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {/* Form */}
      <TeacherForm
        key={formKey}
        onSubmit={handleSubmit}
        lessons={lessons}
        initialData={
          editingTeacher
            ? {
                name: editingTeacher.name,
                phone: editingTeacher.phone,
                branch: editingTeacher.branch,
                lessonID: editingTeacher.lessonID,
              }
            : undefined
        }
        isEditing={Boolean(editingTeacher)}
        onCancelEdit={handleCancelEdit}
      />

      {/* Tablo */}
      <TeacherList
        teachers={teachers}
        loading={loading}
        onEdit={handleEdit}
        onDelete={handleDeleteClick}
      />

      {/* Silme Onay Dialogu */}
      <Dialog
        open={Boolean(deleteTarget)}
        onClose={() => setDeleteTarget(null)}
      >
        <DialogTitle>Öğretmeni Sil</DialogTitle>
        <DialogContent>
          <DialogContentText>
            <strong>{deleteTarget?.name}</strong> öğretmeni silmek istediğinize
            emin misiniz? Bu işlem geri alınamaz.
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

      {/* Başarı Snackbar */}
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