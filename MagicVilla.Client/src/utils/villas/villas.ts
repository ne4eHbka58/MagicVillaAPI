import ky from "ky";
interface Villa {
  id: number;
  name: string;
  details?: string;
  rate: number;
  occupancy?: number;
  sqft?: number;
  imageUrl?: string;
  amenity?: string;
}

interface VillaCreateDTO {
  Name: string;
  name: string;
  details?: string;
  rate: number;
  occupancy?: number;
  sqft?: number;
  imageUrl?: string;
  amenity?: string;
}

interface APIResponse {
  statusCode: number;
  isSuccess: boolean;
  result: Villa | null;
  errorMessages?: string[];
}

export const fetchVillas = async () => {
  try {
    const response = await ky.get("https://localhost:7116/api/VillaAPI").json<{
      statusCode: number;
      isSuccess: boolean;
      result: Villa[];
    }>();

    return response;
  } catch (e: any) {
    console.log(e);
  }
};

export const fetchVilla = async (id: number): Promise<APIResponse> => {
  try {
    const url = `https://localhost:7116/api/UserAPI/${id}`;

    const response = await ky.get(url);

    const data: APIResponse = await response.json();

    return data;
  } catch (error: any) {
    console.error("Ошибка при запросе виллы:", error);

    // Неизвестная ошибка
    return {
      statusCode: error.response?.status || 500,
      isSuccess: false,
      result: null,
      errorMessages: ["Неизвестная ошибка"],
    };
  }
};

export const createVilla = async (
  villaData: VillaCreateDTO
): Promise<APIResponse> => {
  try {
    const response = await ky
      .post("https://localhost:7116/api/VillaAPI", {
        json: villaData,
      })
      .json<APIResponse>();

    return response;
  } catch (error: any) {
    return {
      statusCode: error.response?.status || 500,
      isSuccess: false,
      errorMessages: error,
      result: null,
    };
  }
};

export const deleteVilla = async (id: number): Promise<APIResponse> => {
  try {
    const response = await ky
      .delete(`https://localhost:7116/api/VillaAPI/${id}`, {})
      .json<APIResponse>();

    return response;
  } catch (error: any) {
    return {
      statusCode: error.response?.status || 500,
      isSuccess: false,
      errorMessages: error,
      result: null,
    };
  }
};
