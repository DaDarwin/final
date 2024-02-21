<template>
	<!-- Modal Body -->
	<!-- if you want to close by clicking outside the modal, delete the last endpoint:data-bs-backdrop and data-bs-keyboard -->
	<div
		v-if="keep"
		class="modal fade"
		id="keep-modal"
		tabindex="-1"
		role="dialog"
		aria-labelledby="modalTitleId"
		aria-hidden="true">
		<div
			class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-xl"
			role="document">
			<div class="modal-content">
				<div class="modal-body row p-0">
					<div class="col-6 p-0">
						<img
							class="img-fluid"
							:src="keep.img"
							alt="" />
					</div>
					<div
						class="col-6 py-4 px-3 d-flex flex-column justify-content-between align-items-center">
						<div class="d-flex justify-content-between w-50">
							<span
								><i class="mdi mdi-eye-outline">{{ keep.views }}</i></span
							>
							<span
								><i class="mdi mdi-ring">{{ keep.kept }}</i></span
							>

							<button
								type="button"
								class="btn-close"
								data-bs-dismiss="modal"
								aria-label="Close"></button>
						</div>
						<div class="">
							<span class="fs-3">{{ keep.name }}</span>
							<p class="">{{ keep.description }}</p>
						</div>
						<div
							class="d-flex justify-content-between align-items-baseline w-100">
							<button
								v-if="keep.creatorId == account.id"
								type="button"
								class="btn btn-danger h-50 me-2"
								@click="deleteKeep()">
								<i class="mdi mdi-delete"></i> Delete Keep
							</button>

							<form
								v-if="vaults?.length && account?.id"
								@submit.prevent="createVaultKeep()">
								<select
									v-model="vaultData.vaultId"
									class="form-control">
									<option
										disabled
										selected>
										Select A Vault
									</option>
									<option
										v-for="vault in vaults"
										:value="vault.id">
										{{ vault.name }}
									</option>
								</select>
								<button class="btn btn-secondary w-100 mt-1">
									Add to Vault
								</button>
							</form>
							<div class="d-flex align-items-center">
								<ProfileIcon :profile="keep.creator" />
								<span class="fs-3 ps-1">{{ keep.creator.name }}</span>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import ProfileIcon from "./ProfileIcon.vue";
import Pop from "../utils/Pop";
import { keepService } from "../services/KeepService";
import { Modal } from "bootstrap";
export default {
	setup() {
		const vaultData = ref({});
		return {
			vaultData,
			keep: computed(() => AppState.activeKeep),
			account: computed(() => AppState.account),
			vaults: computed(() => AppState.accountVaults),
			async deleteKeep() {
				try {
					const res = await Pop.confirm(
						"Are You Sure You want to delete this keep?"
					);
					if (!res) {
						return;
					}
					await keepService.deleteKeep(this.keep.id);
					Modal.getOrCreateInstance("#keep-modal").hide();
				} catch (error) {
					Pop.error(error);
				}
			},
			async createVaultKeep() {
				try {
					vaultData.value.keepId = this.keep.id;
					await keepService.createVaultKeep(vaultData.value);
					Pop.success("Keep Added!");
				} catch (error) {
					Pop.error(error);
				}
			},
		};
	},
	components: { ProfileIcon },
};
</script>

<style lang="scss" scoped></style>
