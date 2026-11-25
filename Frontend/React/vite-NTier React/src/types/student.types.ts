import type { IBaseEntity } from './base.types';

// ============================================================================
// 🧠 DÜZELTME & AÇIKLAMA: StudentDTO Alan Uyumları
// ============================================================================
// 1. `classID`: Backend C# modelinde ve Swagger'da alan adı `classID` (büyük ID)
//    şeklindedir. JavaScript/TypeScript'te `classId` yazılırsa backend bu alanı
//    eşleştiremez ve veritabanına null/0 gider.
// 2. `dateOfBirth`: HTML `<input type="date">` elemanları ve JSON API iletişimi
//    tarihleri "YYYY-MM-DD" veya ISO string ("2026-05-15T00:00:00") olarak taşır.
//    JavaScript `Date` nesnesi doğrudan form inputlarında kullanılmaya çalışıldığında
//    tarayıcı uyarı verir. Bu yüzden string | null olarak tutulur.
// 3. `className`: Backend GET /api/Student sorgusunda sınıf adını da döner.
// ============================================================================

export interface StudentDTO extends IBaseEntity {
  name: string | null;
  gender: boolean | null; // true: Erkek, false: Kadın, null: Belirtilmemiş
  classID: number | null; // DÜZELTME: classId yerine Swagger ile tam uyumlu classID
  className?: string | null; // GET isteklerinde dönen sınıf adı
  dateOfBirth: string | null; // DÜZELTME: Date nesnesi yerine ISO/HTML string "YYYY-MM-DD"
  phone: string | null; // Telefon numarası
}

export type StudentCreateDTO = Omit<StudentDTO, 'id' | 'className'>;
