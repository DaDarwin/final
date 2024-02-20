<template>
	<span
		class="rounded-circle h-fit overflow-hidden p-0 work"
		:title="`Go to ${profile.name}'s Profile?'`">
		<router-link
			:to="{ name: 'Profile', params: { id: profile.id } }"
			:title="`Go to ${profile.name}'s Profile?'`"
			class="h-fit work">
			<img
				:src="profile.picture"
				:alt="`Picture of ${profile.name}`"
				:title="`Go to ${profile.name}'s Profile?'`"
				class="img-fluid w-100 rounded-circle work" />
		</router-link>
	</span>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import { Account } from "../models/Account";
export default {
	props: { profile: { required: true } },
	setup(props) {
		return {};
	},
};
</script>

<style lang="scss" scoped>
.work {
	aspect-ratio: 1;
	width: 10vh;
	height: 10vh;
}
</style>
