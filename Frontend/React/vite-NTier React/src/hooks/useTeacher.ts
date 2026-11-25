import {useCrud} from './useCrud';
import teacherService from '../services/teacherService';
import type { TeacherDTO } from '../types/teacher.types';

export function useTeachers() {
  const {
    items: teachers,
    loading,
    error,
    fetchAll: fetchTeachers,
    createItem: addTeacher,
    updateItem: updateTeacher,
    deleteItem: deleteTeacher,
  } = useCrud<TeacherDTO>(teacherService);
  return {
    teachers,
    loading,
    error,
    addTeacher,
    updateTeacher,
    deleteTeacher,
    fetchTeachers,
  };
}
