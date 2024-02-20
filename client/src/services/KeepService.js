import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { api } from "./AxiosService";

class KeepService {
	async getKeeps() {
		const res = await api.get("api/keeps");
		AppState.keeps = res.data.map((pojo) => new Keep(pojo));
	}

	async getKeep(id) {
		const res = await api.get(`api/keeps/${id}`);
		AppState.activeKeep = new Keep(res.data);
	}
}

export const keepService = new KeepService();
