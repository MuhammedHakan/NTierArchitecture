import { useState } from 'react';
import {
  Box,
  TextField,
  Button,
  Stack,
  Typography,
  Radio,
  FormControlLabel,
  RadioGroup,
  FormControl,
  FormLabel,
  InputLabel,
  Select,
  MenuItem,
} from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import type { StudentCreateDTO } from '../../types/student.types';
import type { ClassDTO } from '../../types/class.types';

// ============================================================================
// 🧠 DÜZELTME & AÇIKLAMA: StudentsForm Hata Düzeltmeleri
// ============================================================================
// 1. RadioGroup & Label Tersliği:
//    ❌ value="male" olanın etiketi "Female", value="female" olanın "Male" yapılmıştı.
//    💡 Düzeltildi: "male" -> Erkek, "female" -> Kadın.
//    Ayrıca RadioGroup string beklediğinden `gender === true ? 'male' : ...`
//    şeklinde string'e dönüştürüldü.
//
// 2. Doğum Tarihi & Date Nesnesi Hatası:
//    ❌ `new Date(e.target.value)` ile Date nesnesi atanıyordu, input type="date"
//       ise "YYYY-MM-DD" string beklediğinden konsolda uyarı verip boş kalıyordu.
//    💡 Düzeltildi: Doğrudan e.target.value (string) saklanır.
//
// 3. Sınıf Seçimi (Dropdown):
//    ❌ Önceden `classId: null` sabit gönderiliyordu ve öğrenci sınıfa atanamıyordu.
//    💡 Düzeltildi: Forma `classes` prop'u eklendi; MUI Select ile sınıf seçtirildi.
// ============================================================================

interface StudentFormProps {
  onSubmit: (data: StudentCreateDTO) => Promise<void>;
  initialData?: StudentCreateDTO;
  classes?: ClassDTO[]; // dropdown'ı için
  isEditing?: boolean;
  onCancelEdit?: () => void;
}

export default function StudentForm({
  onSubmit,
  initialData,
  classes = [],
  isEditing = false,
  onCancelEdit,
}: StudentFormProps) {
  const [name, setName] = useState(initialData?.name ?? '');
  const [phone, setPhone] = useState(initialData?.phone ?? '');
  const [gender, setGender] = useState<boolean | null>(initialData?.gender ?? null);
  const [dateOfBirth, setDateOfBirth] = useState<string>(
    initialData?.dateOfBirth ? initialData.dateOfBirth.substring(0, 10) : ''
  );
  const [classID, setClassID] = useState<number | ''>(
    initialData?.classID ?? ''
  );
  const [submitting, setSubmitting] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!name.trim() || !phone.trim()) return;

    setSubmitting(true);
    try {
      await onSubmit({
        name: name.trim(),
        phone: phone.trim(),
        gender: gender,
        classID: classID === '' ? null : Number(classID), // DÜZELTME: Swagger uyumlu classID
        dateOfBirth: dateOfBirth ? `${dateOfBirth}T00:00:00` : null, // ISO tarih formatı
      });
      if (!isEditing) {
        setName('');
        setPhone('');
        setGender(null);
        setDateOfBirth('');
        setClassID('');
      }
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mb: 3 }}>
      <Typography variant="h6" gutterBottom>
        {isEditing ? '✏️ Öğrenci Güncelle' : '➕ Yeni Öğrenci Ekle'}
      </Typography>

      <Stack spacing={2}>
        {/* Satır 1: Ad Soyad & Telefon */}
        <Stack direction={{ xs: 'column', sm: 'row' }} spacing={2}>
          <TextField
            label="Öğrenci Ad Soyad"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
            size="small"
            fullWidth
          />
          <TextField
            label="Telefon"
            type="tel"
            value={phone}
            onChange={(e) => setPhone(e.target.value)}
            required
            size="small"
            fullWidth
          />
        </Stack>

        {/* Satır 2: Sınıf Seçimi & Doğum Tarihi */}
        <Stack direction={{ xs: 'column', sm: 'row' }} spacing={2} sx={{ alignItems: 'center' }}>
          {/* Sınıf Dropdown'ı */}
          <FormControl size="small" fullWidth>
            <InputLabel id="class-select-label">Sınıf</InputLabel>
            <Select<number | ''>
              labelId="class-select-label"
              value={classID}
              label="Sınıf"
              onChange={(e) =>
                setClassID(e.target.value ? Number(e.target.value) : '')
              }
            >
              <MenuItem value="">
                <em>Sınıf Yok / Seçilmedi</em>
              </MenuItem>
              {classes.map((cls) => (
                <MenuItem key={cls.id} value={cls.id}>
                  {cls.name} (Kapasite: {cls.capacity})
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          {/* Doğum Tarihi Input'u */}
          <TextField
            label="Doğum Tarihi"
            type="date"
            value={dateOfBirth}
            onChange={(e) => setDateOfBirth(e.target.value)}
            size="small"
            fullWidth
            slotProps={{
              inputLabel: { shrink: true }, // Label'ın placeholder ile çakışmasını önler
            }}
          />
        </Stack>

        {/* Satır 3: Cinsiyet & Kaydet Butonları */}
        <Stack
          direction={{ xs: 'column', sm: 'row' }}
          spacing={2}
          sx={{ alignItems: 'center', justifyContent: 'space-between' }}
        >
          {/* Cinsiyet Radio Butonları */}
          <FormControl component="fieldset">
            <FormLabel component="legend" sx={{ fontSize: '0.85rem' }}>
              Cinsiyet
            </FormLabel>
            <RadioGroup
              row
              name="gender-radio-group"
              value={gender === true ? 'male' : gender === false ? 'female' : ''}
              onChange={(e) => setGender(e.target.value === 'male')}
            >
              <FormControlLabel value="male" control={<Radio size="small" />} label="Erkek" />
              <FormControlLabel value="female" control={<Radio size="small" />} label="Kadın" />
            </RadioGroup>
          </FormControl>

          {/* Butonlar */}
          <Stack direction="row" spacing={1}>
            <Button
              type="submit"
              variant="contained"
              disabled={submitting || !name.trim() || !phone.trim()}
              startIcon={<SaveIcon />}
              color={isEditing ? 'warning' : 'primary'}
            >
              {submitting ? 'Kaydediliyor...' : isEditing ? 'Güncelle' : 'Ekle'}
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
      </Stack>
    </Box>
  );
}
