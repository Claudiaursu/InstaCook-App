import { DatePersonale } from "./date_personale";

export interface User{

  Nume_Utilizator?: string;
  Prenume_Utilizator?: string;
  ParolaHashed: string;
  Date_Personale?: DatePersonale;
  Total_Puncte?: number,
  Username: string,
  Rol?: number
}
