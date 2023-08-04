module.exports = {
  extends: [
    'plugin:react/recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:react-native/all',
    'plugin:prettier/recommended',
    'prettier',
  ],
  rules: {
    'react/react-in-jsx-scope': 'off',
    'react/prop-types': 'error',
    'react/jsx-uses-react': 'off',
    'react/jsx-filename-extension': [
      1,
      { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
    ],
    'react-native/no-unused-styles': 'error',
    'react-native/split-platform-components': 'error',
    'react-native/no-inline-styles': 'error',
    'react-native/no-color-literals': 'warn',
    'react-native/sort-styles': 'off',
    '@typescript-eslint/explicit-module-boundary-types': 'off',
    '@typescript-eslint/no-unused-vars': [
      'error',
      { args: 'all', ignoreRestSiblings: true },
    ],
    '@typescript-eslint/no-explicit-any': 'off',
    'prettier/prettier': 'error',
    'no-unused-vars': [
      'error',
      { vars: 'all', args: 'after-used', ignoreRestSiblings: false },
    ],
    'no-console': 'warn',
  },
  settings: {
    react: {
      version: '18.2.0',
    },
    'import/resolver': {
      alias: {
        map: [['@', './src']],
        extensions: ['.js', '.jsx', '.ts', '.tsx', '.json'],
      },
    },
  },
  parserOptions: {
    ecmaVersion: 2023,
    sourceType: 'module',
    parser: '@typescript-eslint/parser',
  },
  noInlineConfig: true,
  reportUnusedDisableDirectives: true,
  overrides: [
    {
      files: ['*.ts', '*.tsx', '*.d.ts'],
      rules: {
        'no-undef': 'off',
      },
    },
  ],
};
