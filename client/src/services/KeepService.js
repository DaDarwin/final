import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class KeepService {
	async getKeeps() {
		AppState.keeps = [];
		const res = await api.get("api/keeps");
		AppState.keeps = res.data.map((pojo) => new Keep(pojo));
	}

	async getKeep(id) {
		const res = await api.get(`api/keeps/${id}`);
		AppState.activeKeep = new Keep(res.data);
	}

	async deleteKeep(id) {
		const index = AppState.keeps.findIndex((keep) => keep.id == id);
		AppState.keeps.splice(index, 1);
		return api.delete(`api/keeps/${id}`);
	}

	async removeVaultKeep(id) {
		const index = AppState.keeps.findIndex((keep) => keep.id == id);
		AppState.keeps.splice(index, 1);
		await api.delete(`api/vaultKeeps/${id}`);
	}

	async createVaultKeep(data) {
		const res = await api.post("api/vaultkeeps", data);
		const i = AppState.keeps.findIndex((keep) => keep.id == res.data.keepId);
		AppState.keeps[i].kept++;
		AppState.activeKeep.kept++;
	}

	async createKeep(data) {
		const res = await api.post("api/keeps", data);
		const route = useRoute();
		if (
			route.name == "Home" ||
			(route.name == "Profile" && route.params.id == AppState.account.id)
		) {
			AppState.keeps.push(new Keep(res.data));
		}
	}
}

export const keepService = new KeepService();
