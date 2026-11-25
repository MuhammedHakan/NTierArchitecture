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
import type { ClassCreateDTO } from '../../types/class.types';

interface ClassFormProps {
  onSubmit: (data: ClassCreateDTO) => Promise<void>;
  initialData?: ClassCreateDTO;
  isEditing?: boolean;
  onCancelEdit?: () => void;
}

export default function ClassForm({
  onSubmit,
  initialData,
  isEditing = false,
  onCancelEdit,
}: ClassFormProps) {
  // ============================================================================
  // 🧠 HATA & ÇÖZÜM REHBERİ: React 19 "Cascading Render" & "Ref Access" Hatası
  // ============================================================================
  // ❌ HATALI YAKLAŞIM (Eski Alışkanlık):
  //    useEffect(() => {
  //      if (editData) setName(editData.name); // -> ESLint: react-hooks/set-state-in-effect hatası verir!
  //    }, [editData]);
  //
  // ❓ NEDEN HATA VERİR?
  //    Bileşen ekrana çizildikten hemen sonra useEffect içinde senkron setState çağrılırsa,
  //    React zorunlu olarak ikinci bir render dalgası (cascading render) başlatır.
  //    Bu durum performans kaybına ve arayüzde titremelere (flicker) yol açar.
  //
  // 💡 STANDART ÇÖZÜM: "Key Reset Pattern"
  //    Form bileşeninin içine useEffect ile state senkronizasyonu YAZMAYIN.
  //    Bunun yerine başlangıç değerlerini doğrudan useState'e verin.
  //    Üst bileşende (ClassPage) bu forma her düzenlenecek veri değiştiğinde farklı bir `key` verin:
  //    Örn: <ClassForm key={editingId ?? 'new'} initialData={...} />
  //    Böylece React bileşeni sıfırdan mount eder ve state doğal olarak güncellenir.
  // ============================================================================

  const [name, setName] = useState(initialData?.name ?? '');
  const [capacity, setCapacity] = useState<number | ''>(
    initialData?.capacity ?? ''
  );
  const [submitting, setSubmitting] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!name.trim() || capacity === '') return;

    setSubmitting(true);
    try {
      await onSubmit({ name: name.trim(), capacity: Number(capacity) });
      if (!isEditing) {
        setName('');
        setCapacity('');
      }
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mb: 3 }}>
      <Typography variant="h6" gutterBottom>
        {isEditing ? '✏️ Sınıf Güncelle' : '➕ Yeni Sınıf Ekle'}
      </Typography>

      <Stack direction="row" spacing={2} sx={{ alignItems: 'center' }}>
        <TextField
          label="Sınıf Adı"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
          size="small"
          sx={{ minWidth: 200 }}
        />
        <TextField
          label="Kapasite"
          type="number"
          value={capacity}
          onChange={(e) =>
            setCapacity(e.target.value === '' ? '' : Number(e.target.value))
          }
          required
          size="small"
          slotProps={{ htmlInput: { min: 1 } }}
          sx={{ minWidth: 120 }}
        />
        <Button
          type="submit"
          variant="contained"
          disabled={submitting || !name.trim() || capacity === ''}
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
