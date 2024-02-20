<template>
	<nav
		class="d-flex justify-content-between align-items-center sticky-top bg-page pt-1 pb-2 ps-3 pe-4 border-bottom border-secondary position-relative">
		<div class="d-flex h-100 align-items-center">
			<router-link
				class="navbar-brand d-flex"
				:to="{ name: 'Home' }">
				<div class="home fs-3 rounded-pill selectable p-2 me-2 text-secondary">
					Home
				</div>
			</router-link>
			<div
				class="fs-3 rounded-pill selectable p-2 text-secondary"
				type="button"
				data-bs-toggle="modal"
				data-bs-target="#create-keep">
				Create +
			</div>
		</div>

		<div
			class="logo border border-secondary rounded position-absolute translate-middle top-50 start-50 p-1 px-2">
			<p class="p-0 m-0 text-secondary fs-4">
				the
				<br />keepr <br />
				co.
			</p>
		</div>

		<div class="d-flex align-items-center">
			<button
				class="btn btn-secondary-outline border selectable rounded-circle me-2"
				@click="toggleTheme">
				<i
					class="mdi text-secondary"
					:class="
						theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'
					"></i>
			</button>
			<Login />
		</div>
	</nav>
	<KeepForm />
</template>

<script>
import { onMounted, ref } from "vue";
import { loadState, saveState } from "../utils/Store.js";
import Login from "./Login.vue";
import KeepForm from "./KeepForm.vue";
export default {
	setup() {
		const theme = ref(loadState("theme") || "light");

		onMounted(() => {
			document.documentElement.setAttribute("data-bs-theme", theme.value);
		});

		return {
			theme,
			toggleTheme() {
				theme.value = theme.value == "light" ? "dark" : "light";
				document.documentElement.setAttribute("data-bs-theme", theme.value);
				saveState("theme", theme.value);
			},
		};
	},
	components: { Login, KeepForm },
};
</script>

<style scoped>
.logo {
	aspect-ratio: 1/1;
	p {
		line-height: 23px;
	}
}

nav {
	height: 90px;
}

@media screen and (max-width: 768px) {
	.home {
		display: none;
	}
}
</style>
