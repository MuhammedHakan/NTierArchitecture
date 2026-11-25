import { ApiClient } from './apiClient';
import type { DiscontinuityDTO } from '../types/discontinuity.types';

// ============================================================================
// 🔌 SERVİS KATMANI: Discontinuity API Servisi (Soyutlama)
// ============================================================================
// `ApiClient<T>` generic sınıfımız, CRUD metotlarını (getAll, getById, create, update, delete)
// bir kez tanımlayıp tüm varlıklar için tekrar kullanmamızı sağlar.
//
// Burada sadece endpoint adını (`/Discontinuity`) ve veri tipini (`DiscontinuityDTO`)
// belirterek tek satırda tam teşekküllü bir API servisi elde ediyoruz:
// - discontinuityService.getAll()           -> GET    http://localhost:5199/api/Discontinuity
// - discontinuityService.getById(id)        -> GET    http://localhost:5199/api/Discontinuity/{id}
// - discontinuityService.create(data)       -> POST   http://localhost:5199/api/Discontinuity
// - discontinuityService.update(id, data)   -> PUT    http://localhost:5199/api/Discontinuity/{id}
// - discontinuityService.delete(id)         -> DELETE http://localhost:5199/api/Discontinuity/{id}
// ============================================================================

const discontinuityService = new ApiClient<DiscontinuityDTO>('/Discontinuity');

export default discontinuityService;
