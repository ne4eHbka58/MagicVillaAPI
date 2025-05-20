import { useEffect, useState } from "react";
import {
  fetchVillasNumbers,
  deleteVillaNumber,
} from "../../utils/villasNumbers/villasNumbers";
import styles from "./VillasNumbersApi.module.css";
import { ReactComponent as TrashIcon } from "../../assets/svg/trashcan.svg";
import { ReactComponent as EditIcon } from "../../assets/svg/edit.svg";
import { useNavigate } from "react-router-dom";

interface VillaNumber {
  villaNo: number;
  villaID: number;
  specialDetails?: string;
}

const VillasNumberApi = () => {
  const navigate = useNavigate();

  const [villas, setVillas] = useState<VillaNumber[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    loadVillasNumbers();
  }, []);

  const loadVillasNumbers = async () => {
    try {
      const response = await fetchVillasNumbers();

      if (response?.result) {
        setVillas(response.result);
      }
    } catch (e) {
      console.error("Ошибка:", e);
      setError("Ошибка загрузки");
    } finally {
      setLoading(false);
    }
  };

  const handleCreate = () => {
    navigate("/createVillaNumber");
  };

  const handleEdit = (villaNo: number) => {
    console.log(villaNo);

    navigate(`/createVillaNumber?villaNo=${villaNo}`);
  };

  const handleDelete = async (id: number) => {
    const response = await deleteVillaNumber(id);
    if (response.isSuccess) {
      console.log("Номер удалён");
      loadVillasNumbers();
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  if (!villas.length) {
    return <div>No villas numbers available</div>;
  }

  return (
    <div className={styles.container}>
      <div className={styles.row}>
        <div>
          <h1 className={styles.blueText}>Список Номеров</h1>
        </div>
        <div>
          <button className={styles.createVillaNumber} onClick={handleCreate}>
            Создать номер
          </button>
        </div>
      </div>

      <table className={styles.table}>
        <thead>
          <tr>
            <th>Номер</th>
            <th>Вилла</th>
            <th>Информация</th>
            <th />
          </tr>
        </thead>
        <tbody>
          {villas.map((villa) => (
            <tr key={villa.villaNo}>
              <td>{villa.villaNo}</td>
              <td>{villa.villaID}</td>
              <td>{villa.specialDetails}</td>
              <td>
                <button
                  onClick={() => {
                    handleEdit(villa.villaNo);
                  }}
                  className={`${styles.editBtn} ${styles.controlBtn}`}
                >
                  <EditIcon className={styles.icon} />
                </button>{" "}
                <button
                  className={`${styles.deleteBtn} ${styles.controlBtn}`}
                  onClick={() => {
                    handleDelete(villa.villaNo);
                  }}
                >
                  <TrashIcon className={styles.icon} />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default VillasNumberApi;
