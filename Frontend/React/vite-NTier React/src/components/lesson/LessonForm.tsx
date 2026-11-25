import { useState } from 'react';
import {
  Box,
  TextField,
  Button,
  Stack,
  Typography,
} from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import type { LessonCreateDTO } from '../../types/lesson.types';

interface LessonFormProps {
  onSubmit: (data: LessonCreateDTO) => Promise<void>;
  initialData?: LessonCreateDTO;
  isEditing?: boolean;
  onCancelEdit?: () => void;
}

export default function LessonForm({
  onSubmit,
  initialData,
  isEditing = false,
  onCancelEdit,
}: LessonFormProps) {
  const [name, setName] = useState(initialData?.name ?? '');
  const [weeklyHour, setWeeklyHour] = useState<number | ''>(
    initialData?.weeklyHour ?? ''
  );
  const [submitting, setSubmitting] = useState(false);

  const isValid =
    name.trim().length >= 2 &&
    weeklyHour !== '' &&
    Number(weeklyHour) > 0;

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!isValid) return;

    setSubmitting(true);
    try {
      await onSubmit({
        name: name.trim(),
        weeklyHour: Number(weeklyHour),
      });
      if (!isEditing) {
        setName('');
        setWeeklyHour('');
      }
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mb: 3 }}>
      <Typography variant="h6" gutterBottom>
        {isEditing ? '✏️ Ders Güncelle' : '➕ Yeni Ders Ekle'}
      </Typography>

      <Stack
        direction={{ xs: 'column', sm: 'row' }}
        spacing={2}
        sx={{ alignItems: { sm: 'center' } }}
      >
        <TextField
          label="Ders Adı"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
          size="small"
          sx={{ minWidth: 200 }}
          slotProps={{ htmlInput: { minLength: 2, maxLength: 50 } }}
        />
        <TextField
          label="Haftalık Saat"
          type="number"
          value={weeklyHour}
          onChange={(e) =>
            setWeeklyHour(e.target.value === '' ? '' : Number(e.target.value))
          }
          required
          size="small"
          slotProps={{ htmlInput: { min: 1, step: 1 } }}
          sx={{ minWidth: 140 }}
        />
        <Button
          type="submit"
          variant="contained"
          disabled={submitting || !isValid}
          startIcon={<SaveIcon />}
          color={isEditing ? 'warning' : 'primary'}
        >
          {submitting
            ? 'Kaydediliyor...'
            : isEditing
              ? 'Güncelle'
              : 'Ekle'}
        </Button>
        {isEditing && onCancelEdit && (
          <Button
            variant="outlined"
            color="inherit"
            onClick={onCancelEdit}
            startIcon={<CancelIcon />}
          >
            İptal
          </Button>
        )}
      </Stack>
    </Box>
  );
}
