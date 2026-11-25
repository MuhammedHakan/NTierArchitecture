import type { IBaseEntity } from '../types/base.types';
import httpClient from './httpClient';

/**
 * Generic CRUD API Client
 * T extends IBaseEntity → T'nin mutlaka bir 'id' alanı olması gerektiğini garanti eder.
 *
 * ============================================================================
 * 🧠 HATA & ÇÖZÜM REHBERİ: TypeScript 6 "erasableSyntaxOnly" Hatası
 * ============================================================================
 * ❌ HATALI YAKLAŞIM:
 *    constructor(private readonly endpoint: string) {}
 *    -> Hata: TS1294: This syntax is not allowed when 'erasableSyntaxOnly' is enabled.
 *
 * ❓ NEDEN HATA VERİR?
 *    TypeScript 6 ve modern derleyicilerde "erasableSyntaxOnly" aktifken,
 *    derleyicinin JavaScript'e dönüştürürken silinebilir tipler dışındaki özel
 *    TypeScript sözdizimlerine (parametre özellikleri, enum'lar vb.) izin verilmez.
 *
 * 💡 STANDART ÇÖZÜM:
 *    Sınıf alanını yukarıda açıkça tanımlayın ve constructor gövdesinde atayın:
 *    private endpoint: string;
 *    constructor(endpoint: string) { this.endpoint = endpoint; }
 * ============================================================================
 */
export class ApiClient<T extends IBaseEntity> {
  private endpoint: string;

  constructor(endpoint: string) {
    this.endpoint = endpoint;
  }

  /** GET /api/{endpoint} – Tüm kayıtları getir */
  async getAll(): Promise<T[]> {
    const response = await httpClient.get<T[]>(this.endpoint);
    return response.data;
  }

  /** GET /api/{endpoint}/{id} – Tek kayıt getir */
  async getById(id: number): Promise<T> {
    const response = await httpClient.get<T>(`${this.endpoint}/${id}`);
    return response.data;
  }

  /** POST /api/{endpoint} – Yeni kayıt oluştur */
  async create(data: Omit<T, 'id'>): Promise<string> {
    const response = await httpClient.post<string>(this.endpoint, data);
    return response.data;
  }

  /** PUT /api/{endpoint}/{id} – Kayıt güncelle */
  async update(id: number, data: Partial<T>): Promise<string> {
    const response = await httpClient.put<string>(
      `${this.endpoint}/${id}`,
      data
    );
    return response.data;
  }

  /** DELETE /api/{endpoint}/{id} – Kayıt sil */
  async delete(id: number): Promise<string> {
    const response = await httpClient.delete<string>(
      `${this.endpoint}/${id}`
    );
    return response.data;
  }
}
