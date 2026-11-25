import type { IBaseEntity } from './base.types';

// ============================================================================
// 🧠 HATA & ÇÖZÜM REHBERİ: DTO ve Tip Güvenliği (Type Safety)
// ============================================================================
// ❓ Backend ile Frontend Arasında Neden DTO Kullanılır?
//    Backend C# tarafında API Controller'ları `ClassDTO` döner ve alır.
//    Frontend'de doğrudan serbest nesneler (`any` veya eksik tipler) kullanırsanız:
//    - Yanlış alan adı yazdığınızda (örn: `class_name` yerine `name`) derleyici uyarmaz.
//    - Null kontrolü yapılmadığında runtime'da "Cannot read property of undefined" patlar.
//
// 💡 ÇÖZÜM & KULLANIM:
//    1. Backend DTO'sunun birebir aynısını `interface` olarak tanımlayın.
//    2. Yeni kayıt oluştururken (POST) `id` veritabanında üretileceğinden form tipinde
//       `id` olmamalıdır. Bunun için `Omit<ClassDTO, 'id'>` yardımcı tipini kullanın.
//    3. Güncelleme (PUT/PATCH) yaparken alanların hepsi zorunlu değilse `Partial<ClassDTO>` kullanın.
// ============================================================================

export interface ClassDTO extends IBaseEntity {
  name: string | null;
  capacity: number;
}

// POST işlemlerinde kullanılacak 'id'siz form veri tipi:
export type ClassCreateDTO = Omit<ClassDTO, 'id'>;
