export const dev = window.location.origin.includes("localhost");
export const baseURL = dev ? "https://localhost:7045" : "https://keeper.moresus.com";
export const useSockets = false;
export const domain = ${{secrets.AUTH0_DOMAIN}};
export const clientId = ${secrets.CLIENTID};
export const audience = ${{secrets.AUTH0_AUDIENCE}};
