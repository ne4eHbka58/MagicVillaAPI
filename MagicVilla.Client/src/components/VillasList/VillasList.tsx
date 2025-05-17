import React, { useEffect, useState } from "react";
import styles from "./VillasList.module.css";
import VillaCard from "../VillaCard/VillaCard";
import { fetchVillas } from "../../utils/villas/villas";

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

const VillasList = () => {
  const [villas, setVillas] = useState<Villa[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadVillas = async () => {
      try {
        const response = await fetchVillas();
        console.log("Полные данные с API:", JSON.stringify(response, null, 2));

        if (response?.result) {
          console.log("Первая вилла в массиве:", response.result[0]);
          setVillas(response.result);
        }
      } catch (e) {
        console.error("Ошибка:", e);
        setError("Ошибка загрузки");
      } finally {
        setLoading(false);
      }
    };

    loadVillas();

    console.log(villas);
  }, []);

  if (loading) {
    return <div className={styles.loading}>Loading...</div>;
  }

  if (error) {
    return <div className={styles.error}>{error}</div>;
  }

  if (!villas.length) {
    return <div className={styles.empty}>No villas available</div>;
  }

  return (
    <div className={styles.villasList}>
      {villas.map((villa) => (
        <VillaCard
          key={villa.id}
          name={villa.name}
          details={villa.details}
          rate={villa.rate}
          occupancy={villa.occupancy}
          sqft={villa.sqft}
          imageUrl={villa.imageUrl}
          amenity={villa.amenity}
        />
      ))}
    </div>
  );
};

export default VillasList;
