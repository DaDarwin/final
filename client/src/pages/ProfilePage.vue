<template>
	<div class="row justify-content-center mx-5">
		<header
			v-if="profile"
			class="position-relative mb-5">
			<img
				class="w-100 rounded coverImg"
				:src="profile.coverImg"
				alt="" />
			<div class="position-absolute top-100 start-50 translate-middle">
				<div
					class="d-flex justify-content-center align-items-center flex-column">
					<img
						class="rounded-circle icon"
						:src="profile.picture"
						alt="" />
					<div class="text-center fs-4">
						{{ vaults.length }} <i class="mdi mdi-safe"></i> Vaults ||
						{{ keeps.length }} <i class="mdi mdi-flask"></i> Keeps
					</div>
				</div>
			</div>
		</header>
		<div
			v-if="vaults.length"
			class="mt-5 row">
			<div class="fs-2 text-center col-12 mt-5">Vaults</div>
			<VaultCard
				v-for="vault in vaults"
				:vault="vault"
				class="col-6 col-md-3" />
		</div>
		<br />
		<KeepModal />
		<div class="fs-2 w-50 text-center">Keeps</div>
		<div
			v-if="keeps.length"
			class="mason pt-2 col-12 md-col-10">
			<KeepCard
				v-for="keep in keeps"
				:keep="keep" />
		</div>
	</div>
</template>

<script>
import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import { computed, ref, onMounted, watchEffect } from "vue";
import Pop from "../utils/Pop";
import KeepCard from "../components/KeepCard.vue";
import VaultCard from "../components/VaultCard.vue";
import { profileService } from "../services/ProfileService";
export default {
	setup() {
		const route = useRoute();

		watchEffect((route) => {
			getProfile();
			getProfileVaults();
			getProfileKeeps();
		});

		async function getProfile() {
			try {
				profileService.getProfile(route.params.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		async function getProfileVaults() {
			try {
				profileService.getProfileVaults(route.params.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		async function getProfileKeeps() {
			try {
				profileService.getProfileKeeps(route.params.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			profile: computed(() => AppState.activeProfile),
			vaults: computed(() => AppState.vaults),
			keeps: computed(() => AppState.keeps),
		};
	},
	components: { VaultCard, KeepCard },
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

img {
	object-fit: cover;
	object-position: center;
}
.icon {
	aspect-ratio: 1;
	height: 20vh;
}
header {
	margin-top: 50px;
}

.coverImg {
	max-height: 40vh;
}
</style>
