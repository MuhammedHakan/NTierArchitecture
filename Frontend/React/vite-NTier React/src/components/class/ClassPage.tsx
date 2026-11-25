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
import { useClasses } from '../../hooks/useClasses';
import type { ClassDTO, ClassCreateDTO } from '../../types/class.types';
import ClassForm from './ClassForm';
import ClassList from './ClassList';

export default function ClassPage() {
  const { classes, loading, error, addClass, updateClass, deleteClass } =
    useClasses();

  const [editingClass, setEditingClass] = useState<ClassDTO | null>(null);
  const [deleteTarget, setDeleteTarget] = useState<ClassDTO | null>(null);
  const [snackbar, setSnackbar] = useState<string | null>(null);

  const handleSubmit = async (data: ClassCreateDTO) => {
    if (editingClass) {
      await updateClass(editingClass.id, data);
      setEditingClass(null);
      setSnackbar('Sınıf başarıyla güncellendi.');
    } else {
      await addClass(data);
      setSnackbar('Sınıf başarıyla eklendi.');
    }
  };

  const handleEdit = (cls: ClassDTO) => {
    setEditingClass(cls);
  };

  const handleCancelEdit = () => {
    setEditingClass(null);
  };

  const handleDeleteClick = (id: number) => {
    const cls = classes.find((c) => c.id === id) ?? null;
    setDeleteTarget(cls);
  };

  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;
    await deleteClass(deleteTarget.id);
    setDeleteTarget(null);
    setSnackbar('Sınıf başarıyla silindi.');
  };

  const formKey = editingClass ? `edit-${editingClass.id}` : 'create';

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      {/* Başlık */}
      <Typography
        variant="h4"
        gutterBottom
        sx={{ display: 'flex', alignItems: 'center', gap: 1 }}
      >
        <SchoolIcon fontSize="large" color="primary" />
        Sınıf Yönetimi
      </Typography>

      <Divider sx={{ mb: 3 }} />

      {/* Hata mesajı */}
      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {/* Form */}
      <ClassForm
        key={formKey}
        onSubmit={handleSubmit}
        initialData={
          editingClass
            ? { name: editingClass.name, capacity: editingClass.capacity }
            : undefined
        }
        isEditing={Boolean(editingClass)}
        onCancelEdit={handleCancelEdit}
      />

      {/* Tablo */}
      <ClassList
        classes={classes}
        loading={loading}
        onEdit={handleEdit}
        onDelete={handleDeleteClick}
      />

      {/* Silme Onay Dialogu */}
      <Dialog
        open={Boolean(deleteTarget)}
        onClose={() => setDeleteTarget(null)}
      >
        <DialogTitle>Sınıfı Sil</DialogTitle>
        <DialogContent>
          <DialogContentText>
            <strong>{deleteTarget?.name}</strong> sınıfını silmek istediğinize
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
