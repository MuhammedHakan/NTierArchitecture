import { useCrud } from './useCrud';
import lessonService from '../services/lessonService';
import type { LessonDTO } from '../types/lesson.types';

export function useLessons() {
  const {
    items: lessons,
    loading,
    error,
    fetchAll: fetchLessons,
    createItem: addLesson,
    updateItem: updateLesson,
    deleteItem: deleteLesson,
  } = useCrud<LessonDTO>(lessonService);

  return {
    lessons,
    loading,
    error,
    addLesson,
    updateLesson,
    deleteLesson,
    fetchLessons,
  };
}

export default useLessons;
