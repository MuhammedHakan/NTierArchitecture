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
import useLessons from '../../hooks/useLessons';
import type { LessonDTO, LessonCreateDTO } from '../../types/lesson.types';
import LessonForm from './LessonForm';
import LessonList from './LessonList';

export default function LessonPage() {
  const { lessons, loading, error, addLesson, updateLesson, deleteLesson } =
    useLessons();

  const [editingLesson, setEditingLesson] = useState<LessonDTO | null>(null);
  const [deleteTarget, setDeleteTarget] = useState<LessonDTO | null>(null);
  const [snackbar, setSnackbar] = useState<string | null>(null);

  const handleSubmit = async (data: LessonCreateDTO) => {
    if (editingLesson) {
      await updateLesson(editingLesson.id, data);
      setEditingLesson(null);
      setSnackbar('Ders başarıyla güncellendi.');
    } else {
      await addLesson(data);
      setSnackbar('Ders başarıyla eklendi.');
    }
  };

  const handleEdit = (lesson: LessonDTO) => {
    setEditingLesson(lesson);
  };

  const handleCancelEdit = () => {
    setEditingLesson(null);
  };

  const handleDeleteClick = (id: number) => {
    const lesson = lessons.find((l) => l.id === id) ?? null;
    setDeleteTarget(lesson);
  };

  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;
    await deleteLesson(deleteTarget.id);
    setDeleteTarget(null);
    setSnackbar('Ders başarıyla silindi.');
  };

  const formKey = editingLesson ? `edit-${editingLesson.id}` : 'create';

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      {/* Başlık */}
      <Typography
        variant="h4"
        gutterBottom
        sx={{ display: 'flex', alignItems: 'center', gap: 1 }}
      >
        <SchoolIcon fontSize="large" color="primary" />
        Ders Yönetimi
      </Typography>

      <Divider sx={{ mb: 3 }} />

      {/* Hata mesajı */}
      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {/* Form */}
      <LessonForm
        key={formKey}
        onSubmit={handleSubmit}
        initialData={
          editingLesson
            ? { name: editingLesson.name, weeklyHour: editingLesson.weeklyHour }
            : undefined
        }
        isEditing={Boolean(editingLesson)}
        onCancelEdit={handleCancelEdit}
      />

      {/* Tablo */}
      <LessonList
        lessons={lessons}
        loading={loading}
        onEdit={handleEdit}
        onDelete={handleDeleteClick}
      />

      {/* Silme Onay Dialogu */}
      <Dialog
        open={Boolean(deleteTarget)}
        onClose={() => setDeleteTarget(null)}
      >
        <DialogTitle>Dersi Sil</DialogTitle>
        <DialogContent>
          <DialogContentText>
            <strong>{deleteTarget?.name}</strong> dersini silmek istediğinize
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
