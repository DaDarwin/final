import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { Vault } from "../models/Vault";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class VaultService {
	async getVault(id) {
		AppState.activeVault = null;
		const res = await api.get(`api/vaults/${id}`);
		logger.log(res);
		AppState.activeVault = new Vault(res.data);
	}

	async getKeeps(id) {
		AppState.keeps = [];
		const res = await api.get(`api/vaults/${id}/keeps`);
		AppState.keeps = res.data.map((pojo) => new Keep(pojo));
	}

	async deleteVault(id) {
		AppState.activeVault = null;
		AppState.keeps = [];
		return api.delete(`api/vaults/${id}`);
	}

	async getAccountVaults() {
		const res = await api.get(`api/profiles/${AppState.account.id}/vaults`);
		AppState.accountVaults = res.data.map((pojo) => new Vault(pojo));
	}

	async createVault(data) {
		const res = await api.post("api/vaults", data);
		const route = useRoute();
		if (route.name == "Profile" && route.params.id == AppState.account.id) {
			AppState.vaults.push(new Vault(res.data));
		}
	}
}

export const vaultService = new VaultService();
