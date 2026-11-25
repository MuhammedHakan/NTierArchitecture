import type { IBaseEntity } from './base.types';

// ============================================================================
// 🧠 DÜZELTME & AÇIKLAMA: TeacherDTO Alan Uyumları (400 Hatası Çözümü)
// ============================================================================
// ❌ Önceki hata: Frontend `TeacherName` ve `TeacherPhone` gönderiyordu.
// ❓ Neden 400 verdi?: Backend C# `TeacherDTO` modelinde alan adları `Name`,
//    `Phone`, `Branch`, `LessonID` ve `LessonName` şeklindedir. ASP.NET Core
//    JSON'ı camelCase (`name`, `phone`, `branch`, `lessonID`, `lessonName`)
//    olarak beklediğinden `Name` ve `Phone` null kalıyor, `TeacherValidator`
//    ise "Name is required / Phone is required" diyerek 400 Bad Request dönüyordu.
// 💡 Çözüm: Backend DTO alan adlarıyla birebir uyumlu camelCase alanlar kullanıldı.
// ============================================================================

export interface TeacherDTO extends IBaseEntity {
  name: string | null;
  lessonID: number;
  lessonName?: string | null; // GET isteklerinde backend tarafından döner
  phone: string | null;
  branch: boolean; // true: Sayısal, false: Sözel
}

export type TeacherCreateDTO = Omit<TeacherDTO, 'id' | 'lessonName'>;