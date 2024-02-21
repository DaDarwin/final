<template>
	<div class="d-flex justify-content-center">
		<form
			@submit.prevent="editAccount()"
			class="text-secondary w-50">
			<div>
				<label>Name</label>
				<input
					class="form-control"
					v-model="accountData.name"
					type="text" />
			</div>
			<div>
				<label>Picture</label>
				<input
					class="form-control"
					v-model="accountData.Picture"
					type="text" />
			</div>
			<div>
				<label>Cover Img</label>
				<input
					class="form-control"
					v-model="accountData.coverImg"
					type="text" />
			</div>
			<button class="btn btn-secondary mt-2">Submit</button>
		</form>
	</div>
</template>

<script>
import { computed, ref } from "vue";
import { AppState } from "../AppState";
import Pop from "../utils/Pop";
import { accountService } from "../services/AccountService";
export default {
	setup() {
		const accountData = ref({});
		return {
			account: computed(() => AppState.account),
			accountData,
			async editAccount() {
				try {
					await accountService.editAccount(accountData.value);
				} catch (error) {
					Pop.error(error);
				}
			},
		};
	},
};
</script>

<style scoped>
img {
	max-width: 100px;
}
</style>
