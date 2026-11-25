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
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import type { StudentDTO } from '../../types/student.types';


interface StudentListProps {
  students: StudentDTO[];  // 👈 'classes: ClassDTO[]' yerine 'students: StudentDTO[]'
  loading: boolean;
  onEdit: (student: StudentDTO) => void;
  onDelete: (id: number) => void;
}

export default function StudentList({
  students,                // 👈 'classes' yerine 'students'
  loading,
  onEdit,
  onDelete,
}: StudentListProps) {
  if (loading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
        <CircularProgress />
      </Box>
    );
  }

  if (students.length === 0) {
    return (
      <Typography color="text.secondary" sx={{ textAlign: 'center', py: 4 }}>
        Henüz kayıtlı öğrenci bulunmuyor.
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
              Ad
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              Telefon
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold', textAlign: 'center' }}>
              İşlemler
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {students.map((student) => (
            <TableRow
              key={student.id}
              hover
              sx={{ '&:last-child td': { borderBottom: 0 } }}
            >
              <TableCell>{student.id}</TableCell>
              <TableCell>{student.name ?? '—'}</TableCell>
              <TableCell>{student.className ?? student.classID ?? '—'}</TableCell>
              <TableCell sx={{ textAlign: 'center' }}>
                <Tooltip title="Düzenle">
                  <IconButton
                    color="warning"
                    size="small"
                    onClick={() => onEdit(student)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Sil">
                  <IconButton
                    color="error"
                    size="small"
                    onClick={() => onDelete(student.id)}
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
