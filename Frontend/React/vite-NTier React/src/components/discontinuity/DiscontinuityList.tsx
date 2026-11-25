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
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import CancelIcon from '@mui/icons-material/Cancel';
import type { DiscontinuityDTO } from '../../types/discontinuity.types';
import type { StudentDTO } from '../../types/student.types';

// ============================================================================
// 📊 UI TABLOSU: DiscontinuityList (Devamsızlık Listeleme Tablosu)
// ============================================================================
// 1. Kendi kendini import etme (circular/self import) hatası giderildi.
// 2. Sayfadan kopyalanan gereksiz importlar temizlendi.
// 3. Eksiksiz Table, TableHead, TableBody ve işlem butonları oluşturuldu.
// ============================================================================

interface DiscontinuityListProps {
  /** Listelenecek devamsızlık kayıtları dizisi */
  discontinuities: DiscontinuityDTO[];
  /** Yüklenme durumu (Spinner için) */
  loading: boolean;
  /** Öğrenci isimlerini eşleştirmek için öğrenci listesi (Opsiyonel) */
  students?: StudentDTO[];
  /** Düzenleme butonuna tıklandığında çalışacak fonksiyon */
  onEdit: (discontinuity: DiscontinuityDTO) => void;
  /** Silme butonuna tıklandığında çalışacak fonksiyon (ilgili ID'yi gönderir) */
  onDelete: (id: number) => void;
}

/**
 * Tarihi 'GG.AA.YYYY' (Örn: 13.11.2026) Türkçe formatına çeviren yardımcı fonksiyon
 */
function formatDate(dateStr: string | null | undefined): string {
  if (!dateStr) return '—';
  try {
    const date = new Date(dateStr);
    if (isNaN(date.getTime())) return dateStr.substring(0, 10);
    return date.toLocaleDateString('tr-TR', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
    });
  } catch {
    return dateStr.substring(0, 10);
  }
}

export default function DiscontinuityList({
  discontinuities,
  loading,
  students = [],
  onEdit,
  onDelete,
}: DiscontinuityListProps) {
  // 1. Durum: API'den veriler henüz yükleniyorsa Spinner göster
  if (loading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
        <CircularProgress />
      </Box>
    );
  }

  // 2. Durum: Yükleme bitti ama liste boşsa kullanıcıya bilgi ver
  if (!discontinuities || discontinuities.length === 0) {
    return (
      <Typography color="text.secondary" sx={{ textAlign: 'center', py: 4 }}>
        Henüz kayıtlı devamsızlık bulunmuyor.
      </Typography>
    );
  }

  // Öğrenci ismini önce item'dan, yoksa students listesinden bulur
  const getStudentName = (item: DiscontinuityDTO) => {
    if (item.studentName) return item.studentName;
    const student = students.find((s) => s.id === item.studentID);
    return student ? student.name : `Öğrenci No: ${item.studentID}`;
  };

  // 3. Durum: Veriler varsa tabloyu oluştur ve render et
  return (
    <TableContainer component={Paper} variant="outlined">
      <Table>
        {/* Tablo Başlıkları */}
        <TableHead>
          <TableRow sx={{ backgroundColor: 'primary.main' }}>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>ID</TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Öğrenci</TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Devamsızlık Tarihi</TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Süre</TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Durum</TableCell>
            <TableCell sx={{ color: 'white', fontWeight: 'bold', textAlign: 'center' }}>
              İşlemler
            </TableCell>
          </TableRow>
        </TableHead>

        {/* Tablo Gövdesi (Kayıtlar Döngüsü) */}
        <TableBody>
          {discontinuities.map((item) => (
            <TableRow
              key={item.id}
              hover
              sx={{ '&:last-child td': { borderBottom: 0 } }}
            >
              {/* Kayıt ID */}
              <TableCell>{item.id}</TableCell>

              {/* Öğrenci Adı */}
              <TableCell sx={{ fontWeight: 500 }}>
                {getStudentName(item)}
              </TableCell>

              {/* Devamsızlık Tarihi */}
              <TableCell>{formatDate(item.dateofDiscontinuity)}</TableCell>

              {/* Gün Sayısı Rozeti */}
              <TableCell>
                <Chip
                  label={`${item.days} Gün`}
                  size="small"
                  variant="outlined"
                />
              </TableCell>

              {/* Özür Durumu (Özürlü / Özürsüz) */}
              <TableCell>
                {item.excuse ? (
                  <Chip
                    icon={<CheckCircleIcon fontSize="small" />}
                    label="Özürlü / İzinli"
                    color="warning"
                    size="small"
                  />
                ) : (
                  <Chip
                    icon={<CancelIcon fontSize="small" />}
                    label="Özürsüz"
                    color="error"
                    size="small"
                  />
                )}
              </TableCell>

              {/* Düzenle ve Sil Butonları */}
              <TableCell sx={{ textAlign: 'center' }}>
                <Tooltip title="Düzenle">
                  <IconButton
                    color="warning"
                    size="small"
                    onClick={() => onEdit(item)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Sil">
                  <IconButton
                    color="error"
                    size="small"
                    onClick={() => onDelete(item.id)}
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
