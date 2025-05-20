import ky from "ky";
interface VillaNumber {
  villaNo: number;
  villaID: number;
  specialDetails?: string;
}

interface APIResponse {
  statusCode: number;
  isSuccess: boolean;
  result: VillaNumber | null;
  errorMessages?: string[];
}

export const fetchVillasNumbers = async () => {
  try {
    const response = await ky
      .get("https://localhost:7116/api/VillaNumberAPI")
      .json<{
        statusCode: number;
        isSuccess: boolean;
        result: VillaNumber[];
      }>();

    return response;
  } catch (e: any) {
    console.log(e);
  }
};

export const fetchVillaNumber = async (
  villaNo: number
): Promise<APIResponse> => {
  try {
    const url = `https://localhost:7116/api/VillaNumberAPI/${villaNo}`;

    const response = await ky.get(url);

    const data: APIResponse = await response.json();

    return data;
  } catch (error: any) {
    return {
      statusCode: error.response?.status || 500,
      isSuccess: false,
      result: null,
      errorMessages: ["Неизвестная ошибка"],
    };
  }
};

export const createVillaNumber = async (
  villaData: VillaNumber
): Promise<APIResponse> => {
  try {
    const response = await ky
      .post("https://localhost:7116/api/VillaNumberAPI", {
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

export const editVillaNumber = async (
  villaData: VillaNumber
): Promise<APIResponse> => {
  try {
    const response = await ky
      .put(`https://localhost:7116/api/VillaNumberAPI/${villaData.villaNo}`, {
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

export const deleteVillaNumber = async (
  villaNo: number
): Promise<APIResponse> => {
  try {
    const response = await ky
      .delete(`https://localhost:7116/api/VillaNumberAPI/${villaNo}`, {})
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
