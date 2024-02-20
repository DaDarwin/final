<template>
	<div class="">
		<section
			class="row position-relative rounded m-2"
			v-if="vault.id">
			<img
				@click="selectvault()"
				:src="vault.img"
				alt=""
				class="rounded p-0 selectable" />
			<div class="position-absolute bottom-0 start-0 my-2 w-100">
				<div class="d-flex justify-content-between">
					<span
						class="d-flex title fs-3 p-1 text-warning bg-primary bg-opacity-50 rounded-pill">
						{{ vault.name }}
					</span>

					<i
						v-if="vault.isPrivate"
						class="mdi mdi-lock fs-2 text-secondary"></i>
				</div>
			</div>
		</section>
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import { Vault } from "../models/Vault.js";
import Pop from "../utils/Pop";
import { vaultService } from "../services/VaultService";
export default {
	props: { vault: { type: Vault, reqiured: true } },
	setup(props) {
		async function selectVault() {
			try {
				vaultService.getVault(props.vault.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			selectVault,
		};
	},
};
</script>

<style lang="scss" scoped>
section {
	div {
		background-position: center;
		background-size: cover;
	}
}

@media screen and (max-width: 768px) {
	div {
		justify-content: center !important;
	}
}

.title {
	align-items: center;
	text-align: center;
}
</style>
