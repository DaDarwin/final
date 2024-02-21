<template>
	<section class="px-2">
		<div
			v-if="vault?.id"
			class="d-flex flex-column align-items-center position-relative">
			<img
				class="rounded vault-img"
				:src="vault.img"
				alt="" />
			<div
				class="position-absolute text-center bottom-0 translate-middle-y p-2">
				<div class="fs-3">{{ vault.name }}</div>
				<div class="fs-5">by {{ vault.creator.name }}</div>
			</div>
			<div class="p-1">
				<span class="fs-5 pe-2">{{ keeps.length }} Keeps</span>
				<button
					v-if="account.id == vault.creatorId"
					@click="deleteVault()"
					class="btn btn-danger">
					<i class="mdi mdi-delete"></i>
				</button>
			</div>
		</div>
		<div
			v-if="keeps.length"
			class="mason">
			<KeepCard
				v-for="keep in keeps"
				:keep="keep" />
		</div>
	</section>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import KeepCard from "../components/KeepCard.vue";
import Pop from "../utils/Pop";
import { vaultService } from "../services/VaultService";
import { useRoute } from "vue-router";
import { router } from "../router";
export default {
	setup() {
		onMounted(() => {
			getVault();
			getKeeps();
		});
		const route = useRoute();

		async function getVault() {
			try {
				await vaultService.getVault(route.params.id);
			} catch (error) {
				Pop.error(error);
				router.push({ name: "Home" });
			}
		}

		async function getKeeps() {
			try {
				await vaultService.getKeeps(route.params.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			vault: computed(() => AppState.activeVault),
			keeps: computed(() => AppState.keeps),
			account: computed(() => AppState.account),
			async deleteVault() {
				try {
					const res = await Pop.confirm(
						"Are You Sure You want to delete this vault?"
					);
					if (!res) {
						return;
					}
					await vaultService.deleteVault(this.vault.id);
					router.push({ name: "Home" });
					Pop.success("Vault Deleted");
				} catch (error) {
					Pop.error(error);
				}
			},
		};
	},
	components: { KeepCard },
};
</script>

<style lang="scss" scoped>
.mason {
	columns: 20vw;
}

@media screen and (max-width: 768px) {
	.mason {
		columns: 45vw;
	}
}
.vault-img {
	height: 40vh;
	object-fit: cover;
	object-position: center;
}
</style>
