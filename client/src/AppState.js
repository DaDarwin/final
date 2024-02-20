import { reactive } from "vue";
import { Keep } from "./models/Keep.js";
import { Vault } from "./models/Vault.js";
import { Account } from "./models/Account.js";

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
	user: {},
	/** @type {Account} */
	account: {},
	/**@type {Keep[]} */
	keeps: [],
	/**@type {Keep} */
	activeKeep: null,
	/**@type {Vault[]} */
	vaults: [],
	/**@type {Vault} */
	activeVault: null,
	/**@type {Account} */
	activeProfile: null,
});
