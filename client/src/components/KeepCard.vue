<template>
	<section class="row position-relative rounded mb-3 m-1">
		<img
			:src="keep.img"
			alt=""
			class="rounded p-0" />
	</section>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import { Keep } from "../models/Keep";
export default {
	props: { keep: { type: Keep, reqiured: true } },
	setup(props) {
		return {};
	},
};
</script>

<style lang="scss" scoped>
img {
	object-fit: cover;
	object-position: center;
}
</style>
