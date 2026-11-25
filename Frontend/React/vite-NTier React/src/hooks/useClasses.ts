import { useCrud } from './useCrud';
import classService from '../services/classService';
import type { ClassDTO } from '../types/class.types';

/**
 * Class entity'si için özelleştirilmiş hook.
 * Standart `useCrud` generic hook'unu temel alır.
 */
export function useClasses() {
  const {
    items: classes,
    loading,
    error,
    fetchAll: fetchClasses,
    createItem: addClass,
    updateItem: updateClass,
    deleteItem: deleteClass,
  } = useCrud<ClassDTO>(classService);

  return {
    classes,
    loading,
    error,
    addClass,
    updateClass,
    deleteClass,
    fetchClasses,
  };
}