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
import type { ClassDTO } from '../../types/class.types';

interface ClassListProps {
  classes: ClassDTO[];
  loading: boolean;
  onEdit: (cls: ClassDTO) => void;
  onDelete: (id: number) => void;
}

export default function ClassList({
  classes,
  loading,
  onEdit,
  onDelete,
}: ClassListProps) {
  if (loading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
        <CircularProgress />
      </Box>
    );
  }

  if (classes.length === 0) {
    return (
      <Typography color="text.secondary" sx={{ textAlign: 'center', py: 4 }}>
        Henüz kayıtlı sınıf bulunmuyor.
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
              Sınıf Adı
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
              Kapasite
            </TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold', textAlign: 'center' }}>
              İşlemler
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {classes.map((cls) => (
            <TableRow
              key={cls.id}
              hover
              sx={{ '&:last-child td': { borderBottom: 0 } }}
            >
              <TableCell>{cls.id}</TableCell>
              <TableCell>{cls.name ?? '—'}</TableCell>
              <TableCell>{cls.capacity}</TableCell>
              <TableCell sx={{ textAlign: 'center' }}>
                <Tooltip title="Düzenle">
                  <IconButton
                    color="warning"
                    size="small"
                    onClick={() => onEdit(cls)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Sil">
                  <IconButton
                    color="error"
                    size="small"
                    onClick={() => onDelete(cls.id)}
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
