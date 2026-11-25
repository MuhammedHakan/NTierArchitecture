import type { IBaseEntity } from './base.types';

// ============================================================================
// 📚 DTO KATMANI (Data Transfer Object): Devamsızlık (Discontinuity) Tipleri
// ============================================================================
// DTO, Frontend ile Backend API arasında taşınan verinin şeklini (şemasını) belirler.
// TypeScript interface kullanarak compile-time (derleme zamanı) tip güvenliği sağlarız.
// ============================================================================

/**
 * Backend API'den dönen ve backend'e gönderilen tam Devamsızlık veri modeli.
 * IBaseEntity'den türeyerek zorunlu 'id' alanını miras alır.
 */
export interface DiscontinuityDTO extends IBaseEntity {
  /** Devamsızlık yapan öğrencinin benzersiz veritabanı ID'si (Örn: 5) */
  studentID: number;

  /**
   * Devamsızlığın gerçekleştiği tarih.
   * Backend ISO 8601 ("2026-11-13T00:00:00") formatında bekler.
   * HTML <input type="date"> ile uyum için string olarak tutulur.
   */
  dateofDiscontinuity: string;

  /** Öğrencinin kaç gün devamsızlık yaptığı (Örn: 1 gün, 2 gün) */
  days: number;

  /**
   * Devamsızlığın özürlü (raporlu/izinli) olup olmadığı.
   * true  -> Özürlü / İzinli
   * false -> Özürsüz
   */
  excuse: boolean;

  /**
   * İlişkili tablodan (Student) çekilen öğrenci adı.
   * GET isteklerinde backend tarafından doldurulur (isteğe bağlı/nullable).
   */
  studentName?: string | null;
}

/**
 * Yeni bir devamsızlık kaydı eklerken (POST işlemi) kullanılacak form tipi.
 * `id`: Veritabanında otomatik (Identity/Auto-increment) üretildiği için formda gönderilmez.
 * `studentName`: Öğrenci adı veritabanında Student tablosunda olduğundan formda gönderilmez.
 * `Omit<T, K>` yardımcı tipi ile bu iki alan DiscontinuityDTO'dan çıkartılır.
 */
export type DiscontinuityCreateDTO = Omit<DiscontinuityDTO, 'id' | 'studentName'>;
