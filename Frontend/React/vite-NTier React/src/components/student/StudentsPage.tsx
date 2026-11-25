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
import { useStudents } from '../../hooks/useStudents';
import type { StudentDTO, StudentCreateDTO } from '../../types/student.types';
import { useClasses } from '../../hooks/useClasses'; // 👈 1. Hook'u import edin
import StudentForm from './StudentsForm';
import StudentList from './StudentsList';
export default function StudentPage() {
  const { students, loading, error, addStudent, updateStudent, deleteStudent } =
    useStudents();
  const { classes } = useClasses(); 
  const [editingStudent, setEditingStudent] = useState<StudentDTO | null>(null);
  const [deleteTarget, setDeleteTarget] = useState<StudentDTO | null>(null);
  const [snackbar, setSnackbar] = useState<string | null>(null);

  const handleSubmit = async (data: StudentCreateDTO) => {
    if (editingStudent) {
      await updateStudent(editingStudent.id, data);
      setEditingStudent(null);
      setSnackbar('Öğrenci başarıyla güncellendi.');
    } else {
      await addStudent(data);
      setSnackbar('Öğrenci başarıyla eklendi.');
    }
  };

  const handleEdit = (cls: StudentDTO) => {
    setEditingStudent(cls);
  };

  const handleCancelEdit = () => {
    setEditingStudent(null);
  };

  const handleDeleteClick = (id: number) => {
  // 💡 ÇÖZÜM: 
  // 1. Dizi olan 'students' üzerinde .find() çağırın.
  // 2. TypeScript 's' parametresinin otomatik olarak StudentDTO olduğunu anlar.
  // 3. Bulamazsa undefined yerine null dönsün diye '?? null' ekleyin.
  const targetStudent = students.find((s) => s.id === id) ?? null;

  setDeleteTarget(targetStudent);
};

  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;
    await deleteStudent(deleteTarget.id);
    setDeleteTarget(null);
    setSnackbar('Öğrenci başarıyla silindi.');
  };

  const formKey = editingStudent ? `edit-${editingStudent.id}` : 'create';

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      {/* Başlık */}
      <Typography
        variant="h4"
        gutterBottom
        sx={{ display: 'flex', alignItems: 'center', gap: 1 }}
      >
        <SchoolIcon fontSize="large" color="primary" />
        Öğrenci Yönetimi
      </Typography>

      <Divider sx={{ mb: 3 }} />

      {/* Hata mesajı */}
      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {/* Form */}
      <StudentForm
        key={formKey}
        onSubmit={handleSubmit}
        classes={classes}
        initialData={
          editingStudent
            ? { 
                name: editingStudent.name, 
                phone: editingStudent.phone,
                gender: editingStudent.gender,
                classID: editingStudent.classID, // 👈 'classId: editingStudent.classId' yerine
                dateOfBirth: editingStudent.dateOfBirth
              }
            : undefined
      }     
        isEditing={Boolean(editingStudent)}
        onCancelEdit={handleCancelEdit}
      />

      {/* Tablo */}
      <StudentList
        students={students}
        loading={loading}
        onEdit={handleEdit}
        onDelete={handleDeleteClick}
      />

      {/* Silme Onay Dialogu */}
      <Dialog
        open={Boolean(deleteTarget)}
        onClose={() => setDeleteTarget(null)}
      >
        <DialogTitle>Öğrenciyi Sil</DialogTitle>
        <DialogContent>
          <DialogContentText>
            <strong>{deleteTarget?.name}</strong> öğrenciyi silmek istediğinize
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
