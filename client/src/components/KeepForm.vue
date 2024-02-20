<template>
	<div
		class="modal fade"
		id="create-keep"
		tabindex="-1"
		aria-hidden="true">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<h1 class="modal-title">Post your Keep!</h1>
					<button
						type="button"
						class="btn-close"
						data-bs-dismiss="modal"
						aria-label="Close"></button>
				</div>
				<div class="modal-body">
					<form action="">
						<div>
							<label for="keep-name">Name</label>
							<input
								id="keep-name"
								class="form-control"
								name="keep-name"
								type="text" />
						</div>
						<div>
							<label for="keep-img">Img</label>
							<input
								id="keep-img"
								class="form-control"
								name="keep-img"
								type="text" />
						</div>
						<div>
							<label for="keep-description">Name</label>
							<textarea
								id="keep-description"
								class="form-control"
								name="keep-description"
								cols="10"
								rows="5"></textarea>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
export default {
	setup() {
		return {};
	},
};
</script>

<style lang="scss" scoped></style>
