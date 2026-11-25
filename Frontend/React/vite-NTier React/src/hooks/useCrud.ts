import { useState, useEffect, useCallback } from 'react';
import type { IBaseEntity } from '../types/base.types';
import type { ApiClient } from '../services/apiClient';

export interface UseCrudReturn<T extends IBaseEntity> {
  items: T[];
  loading: boolean;
  error: string | null;
  fetchAll: () => Promise<void>;
  createItem: (data: Omit<T, 'id'>) => Promise<string>;
  updateItem: (id: number, data: Partial<T>) => Promise<string>;
  deleteItem: (id: number) => Promise<string>;
}

/**
 * Standart Generic CRUD Hook
 * Herhangi bir entity için API operasyonlarını, state ve lifecycle yönetimini sağlar.
 *
 * @param apiClient ApiClient<T> instance'ı
 * @param autoFetch Component mount olduğunda otomatik fetch yapılsın mı? (Varsayılan: true)
 */
export function useCrud<T extends IBaseEntity>(
  apiClient: ApiClient<T>,
  autoFetch = true
): UseCrudReturn<T> {
  const [items, setItems] = useState<T[]>([]);
  const [loading, setLoading] = useState<boolean>(autoFetch);
  const [error, setError] = useState<string | null>(null);

  // Tüm kayıtları getiren fonksiyon
  const fetchAll = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await apiClient.getAll();
      setItems(data);
    } catch {
      setError('Veriler yüklenirken bir hata oluştu.');
    } finally {
      setLoading(false);
    }
  }, [apiClient]);

  // Yeni kayıt ekleme
  const createItem = useCallback(
    async (data: Omit<T, 'id'>) => {
      const result = await apiClient.create(data);
      await fetchAll();
      return result;
    },
    [apiClient, fetchAll]
  );

  // Kayıt güncelleme
  const updateItem = useCallback(
    async (id: number, data: Partial<T>) => {
      const result = await apiClient.update(id, data);
      await fetchAll();
      return result;
    },
    [apiClient, fetchAll]
  );

  // Kayıt silme
  const deleteItem = useCallback(
    async (id: number) => {
      const result = await apiClient.delete(id);
      await fetchAll();
      return result;
    },
    [apiClient, fetchAll]
  );

  // ============================================================================
  // 🧠 HATA & ÇÖZÜM REHBERİ: Async Data Fetching & Race Condition Korunması
  // ============================================================================
  // ❌ HATALI YAKLAŞIM:
  //    useEffect(() => {
  //      setLoading(true); // -> Senkron setState ESLint uyarısı verir!
  //      fetchData();
  //    }, []);
  //
  // ❓ KARŞILAŞILABİLECEK 2 BÜYÜK SORUN:
  //    1. Memory Leak: İstek devam ederken kullanıcı sayfadan ayrılırsa (unmount),
  //       gelen yanıt kapalı bileşenin state'ini güncellemeye çalışır.
  //    2. Race Condition: Kullanıcı sayfayı hızla açıp kapatırsa veya filtre değiştirirse,
  //       önceki yavaş istek sonraki hızlı isteğin üzerine yazıp eski veriyi gösterebilir.
  //
  // 💡 STANDART ÇÖZÜM (Boolean Flag Pattern):
  //    1. Effect içinde `let isMounted = true;` bayrağı tanımlayın.
  //    2. Async işlem bitince `if (isMounted)` kontrolü ile state'i güncelleyin.
  //    3. Cleanup fonksiyonunda `return () => { isMounted = false; };` ile iptal edin.
  //    4. `loading` başlangıç değerini doğrudan `useState(autoFetch)` olarak verin,
  //       böylece effect içinde senkron `setLoading(true)` çağırmak zorunda kalmazsınız.
  // ============================================================================
  useEffect(() => {
    if (!autoFetch) return;

    let isMounted = true;

    const loadInitialData = async () => {
      try {
        const data = await apiClient.getAll();
        if (isMounted) {
          setItems(data);
          setError(null);
        }
      } catch {
        if (isMounted) {
          setError('Veriler yüklenirken bir hata oluştu.');
        }
      } finally {
        if (isMounted) {
          setLoading(false);
        }
      }
    };

    loadInitialData();

    return () => {
      isMounted = false;
    };
  }, [apiClient, autoFetch]);

  return {
    items,
    loading,
    error,
    fetchAll,
    createItem,
    updateItem,
    deleteItem,
  };
}
