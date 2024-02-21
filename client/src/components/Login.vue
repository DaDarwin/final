<template>
	<span class="navbar-text">
		<span
			class="selectable text-secondary fs-3"
			@click="login"
			v-if="!user.isAuthenticated">
			Login
		</span>
		<div v-else>
			<div
				v-if="account?.id"
				class="dropdown-center">
				<button
					class="picture rounded-circle dropdown-toggle border-0 p-0"
					data-bs-toggle="dropdown"
					aria-expanded="false">
					<img
						v-if="account.picture || user.picture"
						:src="account.picture || user.picture"
						alt="account photo"
						height="40"
						class="picture img-fluid rounded-circle" />
				</button>
				<ul class="dropdown-menu px-1">
					<li>
						<router-link :to="{ name: 'Home' }">
							<div class="dropdown-item selectable text-secondary">
								<i class="mdi mdi-home"></i>
								Home
							</div>
						</router-link>
					</li>
					<li>
						<router-link :to="{ name: 'Account' }">
							<div class="dropdown-item selectable text-secondary">
								<i class="mdi mdi-account-cog"></i> Manage Account
							</div>
						</router-link>
					</li>
					<li>
						<router-link :to="{ name: 'Profile', params: { id: account.id } }">
							<div class="dropdown-item selectable text-secondary">
								<i class="mdi mdi-account-search"></i>View Profile
							</div>
						</router-link>
					</li>
					<li>
						<div
							class="dropdown-item selectable text-danger"
							@click="logout">
							<i class="mdi mdi-logout"></i>
							logout
						</div>
					</li>
				</ul>
			</div>
		</div>
	</span>
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";
export default {
	setup() {
		return {
			user: computed(() => AppState.user),
			account: computed(() => AppState.account),
			async login() {
				AuthService.loginWithPopup();
			},
			async logout() {
				AuthService.logout({ returnTo: window.location.origin });
			},
		};
	},
};
</script>

<style lang="scss" scoped>
.picture {
	aspect-ratio: 1;
	height: 6vh;
}
</style>
