import { AppState } from "../AppState.js";
import { Account } from "../models/Account.js";
import { Keep } from "../models/Keep.js";
import { Vault } from "../models/Vault.js";
import { api } from "./AxiosService.js";

class ProfileService {
	async getProfile(id) {
		AppState.activeProfile = null;
		const res = await api.get(`api/profiles/${id}`);
		AppState.activeProfile = new Account(res.data);
	}
	async getProfileVaults(id) {
		AppState.vaults = [];
		const res = await api.get(`api/profiles/${id}/vaults`);
		AppState.vaults = res.data.map((pojo) => new Vault(pojo));
	}
	async getProfileKeeps(id) {
		AppState.keeps = [];
		const res = await api.get(`api/profiles/${id}/keeps`);
		AppState.keeps = res.data.map((pojo) => new Keep(pojo));
	}
}

export const profileService = new ProfileService();
