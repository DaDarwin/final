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
						<div class="d-flex justify-content-between align-items-baseline">
							<button
								v-if="keep.creatorId == account.id"
								type="button"
								class="btn btn-danger h-50 me-2">
								<i class="mdi mdi-delete"></i> Delete Keep
							</button>

							<ProfileIcon :profile="keep.creator" />
							<span>{{ keep.creator.name }}</span>
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
export default {
	setup() {
		return {
			keep: computed(() => AppState.activeKeep),
			account: computed(() => AppState.account),
		};
	},
	components: { ProfileIcon },
};
</script>

<style lang="scss" scoped></style>
