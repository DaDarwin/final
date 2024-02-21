<template>
	<div
		class="modal fade"
		id="create-vault"
		tabindex="-1"
		aria-hidden="true">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<h1 class="modal-title">Post your vault!</h1>
					<button
						type="button"
						class="btn-close"
						data-bs-dismiss="modal"
						aria-label="Close"></button>
				</div>
				<div class="modal-body">
					<form @submit.prevent="createVault()">
						<div>
							<label for="vault-name">Name</label>
							<input
								v-model="vaultData.name"
								id="vault-name"
								class="form-control"
								name="vault-name"
								type="text" />
						</div>
						<div>
							<label for="vault-img">Img</label>
							<input
								v-model="vaultData.img"
								id="vault-img"
								class="form-control"
								name="vault-img"
								type="text" />
						</div>
						<div>
							<label for="vault-description">Name</label>
							<textarea
								v-model="vaultData.description"
								id="vault-description"
								class="form-control"
								name="vault-description"
								cols="10"
								rows="5"></textarea>
						</div>
						<button class="btn btn-secondary mt-1">Post</button>
					</form>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import Pop from "../utils/Pop";
import { vaultService } from "../services/VaultService";
export default {
	setup() {
		const vaultData = ref({});
		return {
			vaultData,
			async createVault() {
				try {
					await vaultService.createVault(vaultData.value);
				} catch (error) {
					Pop.error(error);
				}
			},
		};
	},
};
</script>

<style lang="scss" scoped></style>
