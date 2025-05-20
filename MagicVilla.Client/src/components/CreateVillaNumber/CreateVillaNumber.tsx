import { useEffect, useState } from "react";
import styles from "./CreateVillaNumber.module.css";
import {
  validateNumber,
  validateString,
} from "../../utils/checkValidity/checkValidity";
import { useNavigate, useSearchParams } from "react-router-dom";
import {
  createVillaNumber,
  editVillaNumber,
  fetchVillaNumber,
} from "../../utils/villasNumbers/villasNumbers";

interface FormData {
  villaNo?: number;
  villaID: number;
  specialDetails?: string;
}

interface VillaNumberCreateDto {
  villaNo: number;
  villaID: number;
  specialDetails?: string;
}
const CreateVillaNumber = () => {
  const navigate = useNavigate();

  const [isEditing, setIsEditing] = useState(false);

  const [formData, setFormData] = useState<FormData>({
    villaNo: 0,
    villaID: 0,
  });
  const [errors, setErrors] = useState<{
    villaNo: string;
    villaID: string;
    specialDetails?: string;
  }>({
    villaNo: "",
    villaID: "",
  });

  const [searchParams] = useSearchParams();
  const villaNO = Number(searchParams.get("villaNo")); // получаем параметр id из URL

  useEffect(() => {
    // Если есть villaNo в URL, значит это редактирование существующего номера
    if (villaNO) {
      setIsEditing(true);
      // Загружаем данные номера для редактирования
      fetchVillaNumberForEdit(villaNO);
    }
  }, [villaNO]);

  const fetchVillaNumberForEdit = async (villaNo: number) => {
    try {
      const response = await fetchVillaNumber(villaNo);
      if (response.isSuccess) {
        setFormData(response.result);
      } else {
        console.error("Ошибка при загрузке номера:", response.errorMessages);
      }
    } catch (error) {
      console.error("Ошибка:", error);
    }
  };

  const handleBlur = (
    e:
      | React.ChangeEvent<HTMLInputElement>
      | React.FocusEvent<HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleBack = () => {
    navigate("/villaNumberApi");
  };

  const onSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    console.log(formData);

    let isValid = true;
    const newErrors: {
      villaNo: string;
      villaID: string;
      specialDetails?: string;
    } = {
      villaNo: "",
      villaID: "",
    }; // объект с текстом ошибок

    // Валидация номера
    const numberValidation = validateNumber(formData.villaNo, {
      required: true,
      moreThan: 0,
    });
    if (!numberValidation.isValid) {
      newErrors.villaNo = numberValidation.errorMessage;
      isValid = false;
    }

    // Валидация Id виллы
    const villaIDValidation = validateNumber(formData.villaID, {
      required: true,
      moreThan: 0,
    });
    if (!villaIDValidation.isValid) {
      newErrors.villaID = villaIDValidation.errorMessage;
      isValid = false;
    }

    if (isValid) {
      const data: VillaNumberCreateDto = {
        villaNo: villaNO,
        villaID: formData.villaID,
        specialDetails: formData.specialDetails,
      };
      if (isEditing) {
        const response = await editVillaNumber(data);

        if (response.isSuccess) {
          console.log("Успех");
          navigate("/villaNumberApi");
        } else {
          console.log("Неудача!");
          if (response.statusCode == 400) {
            newErrors.villaID = "Нельзя менять ID виллы";
          }
          console.log(response.errorMessages);
        }
      } else {
        data.villaNo = formData.villaNo;
        const response = await createVillaNumber(data);

        if (response.isSuccess) {
          console.log("Успех");
          navigate("/villaNumberApi");
        } else {
          console.log("Неудача!");
          if (response.statusCode == 400) {
            newErrors.villaID = "Id виллы не найден или номер уже занят";
          }
          console.log(response.errorMessages);
        }
      }
    } else {
      newErrors.villaNo = "Ошибка";
      isEditing
        ? console.log("Ошибка при создании номера")
        : console.log("Ошибка при обновлении номера");
    }
    setErrors(newErrors);
  };

  return (
    <form className={styles.form} onSubmit={onSubmit}>
      <div>
        <h1 className={styles.blueText}>
          {isEditing ? "Редактировать номер" : "Создать номер"}
        </h1>
      </div>
      <table>
        <tbody>
          {!isEditing && ( // Если не редактируем, то добавляется ввод номера
            <tr>
              <td>
                <label>Номер</label>
              </td>
              <td className={styles.tdInput}>
                <input
                  className={styles.input}
                  type="number"
                  onBlur={handleBlur}
                  name="villaNo"
                  defaultValue={formData?.villaNo || ""}
                />
                {errors.villaNo && (
                  <div className={styles.error}>{errors.villaNo}</div>
                )}
              </td>
            </tr>
          )}

          <tr>
            <td>
              <label>ID Виллы</label>
            </td>
            <td className={styles.tdInput}>
              <input
                className={styles.input}
                type="number"
                onBlur={handleBlur}
                name="villaID"
                defaultValue={formData?.villaID || ""}
              />
              {errors.villaID && (
                <div className={styles.error}>{errors.villaID}</div>
              )}
            </td>
          </tr>
          <tr>
            <td>
              <label>Информация</label>
            </td>
            <td className={styles.tdInput}>
              <textarea
                className={styles.textarea}
                onBlur={handleBlur}
                name="specialDetails"
                defaultValue={formData?.specialDetails || ""}
              />
            </td>
          </tr>
        </tbody>
      </table>

      <div className={styles.rowBtns}>
        <button
          className={`${styles.backBtn} ${styles.btn}`}
          onClick={handleBack}
        >
          Назад к списку
        </button>
        <button className={`${styles.createBtn} ${styles.btn}`} type="submit">
          {isEditing ? "Редактировать" : "Создать"}
        </button>
      </div>
    </form>
  );
};

export default CreateVillaNumber;
