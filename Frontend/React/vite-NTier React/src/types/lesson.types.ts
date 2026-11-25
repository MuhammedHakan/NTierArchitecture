import type { IBaseEntity } from './base.types';

// Backend'deki LessonDTO ile birebir uyumlu model:
// swagger.json -> LessonDTO { id, name, weeklyHour }
export interface LessonDTO extends IBaseEntity {
  name: string | null;
  weeklyHour: number;
}

// POST işlemlerinde kullanılacak 'id'siz form veri tipi:
export type LessonCreateDTO = Omit<LessonDTO, 'id'>;
