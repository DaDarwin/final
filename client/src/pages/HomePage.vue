<template>
	<section class="container-fluid">
		<div class="row justify-content-center">
			<div
				v-if="keeps.length"
				class="mason pt-2 col-12 md-col-10">
				<KeepCard
					v-for="keep in keeps"
					:keep="keep" />
			</div>
		</div>
	</section>
</template>

<script>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import KeepCard from "../components/KeepCard.vue";
import { keepService } from "../services/KeepService.js";

export default {
	setup() {
		onMounted(() => {
			getKeeps();
		});
		async function getKeeps() {
			try {
				await keepService.getKeeps();
			} catch (error) {
				Pop.error(error);
			}
		}
		return { keeps: computed(() => AppState.keeps) };
	},
	components: { KeepCard },
};
</script>

<style scoped lang="scss">
.mason {
	columns: 20vw;
}

@media screen and (max-width: 768px) {
	.mason {
		columns: 45vw;
	}
}
</style>
