import { defineStore } from "pinia";

export const useSpecialStore = defineStore('specialStore', {
  state: () => ({
    specials: [],
    showSpecials: false,
    loading: false,
    error: null,
  }),

  actions: {
    async getSpecials() {
      this.loading = true;
      try {
        const response = await fetch('/api/Specials');
        console.log("response:", response);
        if (!response.ok) {
          throw new Error('Failed to fetch orders')
        }
        this.specials = await response.json();
      } catch (err) {
        this.error = err.message;
      } finally {
        this.loading = false;
      }
    },

    toggleShowSpecials(value) {
      this.showSpecials = value;
    },
  },

  getters: {
    specialsCount: (state) => state.specials.length,
  },
});
