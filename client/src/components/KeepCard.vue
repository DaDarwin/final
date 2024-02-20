<template>
	<section class="row position-relative rounded mb-3 m-1">
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

			<ProfileIcon
				:profile="keep.creator"
				class="icon position-absolute bottom-0 end-0 w-fit m-1" />
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
export default {
	props: { keep: { type: Keep, reqiured: true } },
	setup(props) {
		async function selectKeep() {
			try {
				await keepService.getKeep(props.keep.id);
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			selectKeep,
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
