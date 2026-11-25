import { useCrud } from './useCrud';
import discontinuityService from '../services/discontinuityService';
import type { DiscontinuityDTO } from '../types/discontinuity.types';

// ============================================================================
// 🪝 HOOK KATMANI: useDiscontinuities (React Durum ve Yaşam Döngüsü Yönetimi)
// ============================================================================
// Custom Hook, bileşenlerin (UI) doğrudan API çağrıları yapmasını engeller.
// Veri çekme, yüklenme (loading), hata (error), ekleme, güncelleme ve silme
// durumlarını tek bir merkezde toplar (Separation of Concerns).
//
// `useCrud` generic hook'u sayesinde:
// 1. Component ilk açıldığında veriler otomatik çekilir (autoFetch: true).
// 2. Herhangi bir CRUD işlemi yapıldığında tablo otomatik güncellenir.
// 3. Aliasing (yeniden adlandırma) ile generic isimler ('items', 'createItem')
//    anlamlı alan adlarına ('discontinuities', 'addDiscontinuity') dönüştürülür.
// ============================================================================

export function useDiscontinuities() {
  const {
    items: discontinuities,               // items -> discontinuities olarak adlandırıldı
    loading,                              // API isteği sürerken true olur (Spinner göstermek için)
    error,                                // Hata oluşursa hata metnini tutar
    fetchAll: fetchDiscontinuities,       // Manuel olarak tüm devamsızlıkları yenilemek için
    createItem: addDiscontinuity,         // POST isteği ile yeni devamsızlık ekler
    updateItem: updateDiscontinuity,      // PUT isteği ile devamsızlığı günceller
    deleteItem: deleteDiscontinuity,      // DELETE isteği ile devamsızlığı siler
  } = useCrud<DiscontinuityDTO>(discontinuityService);

  return {
    discontinuities,
    loading,
    error,
    addDiscontinuity,
    updateDiscontinuity,
    deleteDiscontinuity,
    fetchDiscontinuities,
  };
}
