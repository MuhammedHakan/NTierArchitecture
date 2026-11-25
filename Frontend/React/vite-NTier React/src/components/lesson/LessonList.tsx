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
import type { LessonDTO } from '../../types/lesson.types';

interface LessonListProps {
  lessons: LessonDTO[];
  loading: boolean;
  onEdit: (lesson: LessonDTO) => void;
  onDelete: (id: number) => void;
}
export default function LessonList({
    lessons,
    loading,
    onEdit,
    onDelete,
}: LessonListProps) {
    if (loading) {
        return (
            <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
                <CircularProgress />
            </Box>
        );
    }
    if (lessons.length === 0) {
        return (
            <Typography color="text.secondary" sx={{ textAlign: 'center', py: 4 }}>
                Henüz kayıtlı ders bulunmuyor.
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
                            Ders Adı
                        </TableCell>
                        <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>
                            Haftalık Saat
                        </TableCell>
                        <TableCell sx={{ color: 'white', fontWeight: 'bold', textAlign: 'center' }}>
                            İşlemler
                        </TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {lessons.map((lesson) => (
                        <TableRow key={lesson.id}>
                            <TableCell>{lesson.id}</TableCell>
                            <TableCell>{lesson.name ?? '—'}</TableCell>
                            <TableCell>{lesson.weeklyHour}</TableCell>
                            <TableCell sx={{ textAlign: 'center' }}>
                                <Tooltip title="Düzenle">
                                    <IconButton
                                        color="warning"
                                        size="small"
                                        onClick={() => onEdit(lesson)}
                                    >
                                        <EditIcon />
                                    </IconButton>
                                </Tooltip>
                                <Tooltip title="Sil">
                                        <IconButton
                                            color="error"
                                            size="small"
                                            onClick={() => onDelete(lesson.id)}
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