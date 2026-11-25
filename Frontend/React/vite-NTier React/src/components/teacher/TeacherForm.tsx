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
  FormLabel,
  RadioGroup,
  FormControlLabel,
  Radio,
} from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import type { TeacherCreateDTO } from '../../types/teacher.types';
import type { LessonDTO } from '../../types/lesson.types';

interface TeacherFormProps {
  onSubmit: (data: TeacherCreateDTO) => Promise<void>;
  initialData?: TeacherCreateDTO;
  lessons?: LessonDTO[]; // Dropdown menüsünde derslerin id ve name alanlarını gösterebilmek için LessonDTO kullanılır
  isEditing?: boolean;
  onCancelEdit?: () => void;
}

export default function TeacherForm({
  onSubmit,
  initialData,
  lessons = [],
  isEditing = false,
  onCancelEdit,
}: TeacherFormProps) {
  const [name, setName] = useState(initialData?.name ?? '');
  const [phone, setPhone] = useState(initialData?.phone ?? '');
  // Backend'de Branch boolean tipindedir: true -> Sayısal, false -> Sözel
  const [branch, setBranch] = useState<boolean>(initialData?.branch ?? true);
  const [lessonID, setLessonID] = useState<number | ''>(
    initialData?.lessonID ?? ''
  );
  const [submitting, setSubmitting] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!name.trim() || !phone.trim() || lessonID === '') return;

    setSubmitting(true);
    try {
      await onSubmit({
        name: name.trim(),
        lessonID: Number(lessonID),
        phone: phone.trim(),
        branch: branch,
      });
      if (!isEditing) {
        setName('');
        setPhone('');
        setLessonID('');
        setBranch(true);
      }
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mb: 3 }}>
      <Typography variant="h6" gutterBottom>
        {isEditing ? '✏️ Öğretmen Güncelle' : '➕ Yeni Öğretmen Ekle'}
      </Typography>

      <Stack spacing={2}>
        {/* Satır 1: 1. Öğretmen Adı & 2. Öğretmen Telefon Numarası */}
        <Stack direction={{ xs: 'column', sm: 'row' }} spacing={2}>
          <TextField
            label="Öğretmen Adı"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
            size="small"
            fullWidth
            slotProps={{ htmlInput: { minLength: 2, maxLength: 50 } }}
          />
          <TextField
            label="Öğretmen Telefon Numarası"
            type="tel"
            value={phone}
            onChange={(e) => setPhone(e.target.value)}
            required
            size="small"
            fullWidth
            slotProps={{ htmlInput: { minLength: 3, maxLength: 30 } }}
          />
        </Stack>

        {/* Satır 2: 3. Öğretmenin Dersi & 4. Öğretmenin Branşı */}
        <Stack
          direction={{ xs: 'column', sm: 'row' }}
          spacing={2}
          sx={{ alignItems: { sm: 'center' } }}
        >
          {/* 3. Öğretmenin Dersi (Dropdown) */}
          <FormControl size="small" fullWidth required>
            <InputLabel id="teacher-lesson-select-label">Öğretmenin Dersi</InputLabel>
            <Select<number | ''>
              labelId="teacher-lesson-select-label"
              value={lessonID}
              label="Öğretmenin Dersi"
              onChange={(e) =>
                setLessonID(e.target.value ? Number(e.target.value) : '')
              }
            >
              <MenuItem value="">
                <em>Ders Seçiniz</em>
              </MenuItem>
              {lessons.map((lesson) => (
                <MenuItem key={lesson.id} value={lesson.id}>
                  {lesson.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          {/* 4. Öğretmenin Branşı (Sayısal / Sözel Radio Button) */}
          <FormControl component="fieldset" fullWidth>
            <FormLabel component="legend" sx={{ fontSize: '0.85rem' }}>
              Öğretmenin Branşı
            </FormLabel>
            <RadioGroup
              row
              name="teacher-branch-radio-group"
              value={branch ? 'sayisal' : 'sozel'}
              onChange={(e) => setBranch(e.target.value === 'sayisal')}
            >
              <FormControlLabel
                value="sayisal"
                control={<Radio size="small" />}
                label="Sayısal"
              />
              <FormControlLabel
                value="sozel"
                control={<Radio size="small" />}
                label="Sözel"
              />
            </RadioGroup>
          </FormControl>
        </Stack>

        {/* Satır 3: Kaydet / Güncelle ve İptal Butonları */}
        <Stack direction="row" spacing={1}>
          <Button
            type="submit"
            variant="contained"
            disabled={submitting || !name.trim() || !phone.trim() || lessonID === ''}
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
      </Stack>
    </Box>
  );
}
