import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Typography,
  CircularProgress,
  Box,
  Tooltip,
  Chip,
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import type { TeacherDTO } from '../../types/teacher.types';

interface TeacherListProps {
  teachers: TeacherDTO[];
  loading: boolean;
  onEdit: (teacher: TeacherDTO) => void;
  onDelete: (id: number) => void;
}

export default function TeacherList({
  teachers,
  loading,
  onEdit,
  onDelete,
}: TeacherListProps) {
  if (loading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
        <CircularProgress />
      </Box>
    );
  }
  if (teachers.length === 0) {
    return (
      <Typography color="text.secondary" sx={{ textAlign: 'center', py: 4 }}>
        Henüz kayıtlı öğretmen bulunmuyor.
      </Typography>
    );
  }
  return (
    <TableContainer component={Paper} variant="outlined">
      <Table>
        <TableHead>
          <TableRow sx={{ backgroundColor: 'primary.main' }}>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              ID
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              Öğretmen Adı
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              Telefon
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              Dersi
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              Branş
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold', textAlign: 'center' }}>
              İşlemler
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {teachers.map((teacher) => (
            <TableRow key={teacher.id}>
              <TableCell>{teacher.id}</TableCell>
              <TableCell>{teacher.name}</TableCell>
              <TableCell>{teacher.phone}</TableCell>
              <TableCell>{teacher.lessonName ?? teacher.lessonID}</TableCell>
              <TableCell>
                <Chip
                  label={teacher.branch ? 'Sayısal' : 'Sözel'}
                  color={teacher.branch ? 'primary' : 'secondary'}
                  size="small"
                  variant="outlined"
                />
              </TableCell>
              <TableCell sx={{ textAlign: 'center' }}>
                <Tooltip title="Düzenle">
                  <IconButton
                    color="warning"
                    size="small"
                    onClick={() => onEdit(teacher)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Sil">
                  <IconButton
                    color="error"
                    size="small"
                    onClick={() => onDelete(teacher.id)}
                  >
                    <DeleteIcon />
                  </IconButton>
                </Tooltip>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
