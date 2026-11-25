import { useCrud } from './useCrud';
import studentService from '../services/studentService';
import type { StudentDTO } from '../types/student.types';

// ============================================================================
// 🧠 DÜZELTME & AÇIKLAMA: useStudents Hook İsimlendirmeleri (Aliasing)
// ============================================================================
// ❌ ÖNCEKİ HATA:
//    createItem: addClass, updateItem: updateClass, deleteItem: deleteClass
//    şeklinde Class hook'undan kopyalanıp bırakılmıştı. Fakat StudentsPage içinde
//    `addStudent`, `updateStudent`, `deleteStudent` aranıyordu.
//    Bu durum "addStudent is not a function" çalışma zamanı hatasına yol açıyordu.
//
// 💡 DÜZELTME:
//    useCrud içindeki generic metotları Student bağlamına uygun isimlerle
//    (students, addStudent, updateStudent, deleteStudent) dışarı aktarıyoruz.
// ============================================================================

export function useStudents() {
  const {
    items: students,          // items -> students olarak adlandırıldı
    loading,
    error,
    fetchAll: fetchStudents,  // fetchAll -> fetchStudents
    createItem: addStudent,   // createItem -> addStudent (DÜZELTME: addClass değil)
    updateItem: updateStudent,// updateItem -> updateStudent (DÜZELTME: updateClass değil)
    deleteItem: deleteStudent,// deleteItem -> deleteStudent (DÜZELTME: deleteClass değil)
  } = useCrud<StudentDTO>(studentService);

  return {
    students,
    loading,
    error,
    addStudent,
    updateStudent,
    deleteStudent,
    fetchStudents,
  };
}
