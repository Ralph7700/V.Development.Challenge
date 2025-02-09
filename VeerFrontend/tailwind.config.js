/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",],
  theme: {
    extend: {
      colors:{
        'veer-gray':"#525866",
        'veer-green':"#8CCFB7",
      }
    },
  },
  plugins: [],
}

