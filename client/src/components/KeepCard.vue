<template>
	<section
		class="row position-relative rounded mb-3 m-1"
		v-if="keep.id">
		<img
			@click="selectKeep()"
			data-bs-toggle="modal"
			data-bs-target="#keep-modal"
			:src="keep.img"
			alt=""
			class="rounded p-0 selectable" />
		<div
			class="position-absolute bottom-0 start-0 d-flex justify-content-between my-2 w-100">
			<span
				class="d-flex title fs-3 p-1 text-warning bg-primary bg-opacity-50 rounded-pill">
				{{ keep.name }}
			</span>
		</div>
		<ProfileIcon
			v-if="keep.creator"
			:profile="keep.creator"
			class="icon position-absolute top-0 end-0 w-fit m-1" />
		<div v-if="route.name == 'Vault' && vault.creatorId == account.id">
			<button
				class="btn btn-danger position-absolute top-0 start-0"
				@click="removeKeep()">
				<i class="mdi mdi-close"></i>
			</button>
		</div>
	</section>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import { Keep } from "../models/Keep";
import ProfileIcon from "./ProfileIcon.vue";
import Pop from "../utils/Pop";
import { keepService } from "../services/KeepService";
import { useRoute } from "vue-router";
export default {
	props: { keep: { type: Keep, reqiured: true } },
	setup(props) {
		const route = useRoute();
		async function selectKeep() {
			try {
				await keepService.getKeep(props.keep.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			selectKeep,
			route,
			vault: computed(() => AppState.activeVault),
			account: computed(() => AppState.account),

			async removeKeep() {
				try {
					const res = await Pop.confirm(
						"Are You Sure You want to remove this keep from this vault?"
					);
					if (!res) {
						return;
					}
					await keepService.removeVaultKeep(props.keep.vaultKeepId);
				} catch (error) {
					Pop.error(error);
				}
			},
		};
	},
	components: { ProfileIcon },
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
	.icon {
		display: none;
	}
}

.title {
	align-items: center;
	text-align: center;
}
</style>
